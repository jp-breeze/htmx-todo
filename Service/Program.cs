using DotNetEnv;
using htmx_todo.Data.Extensions;
using htmx_todo.Domain.Extensions;
using htmx_todo.Service.Extensions;

Env.Load();

// Configure Services

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDomainServices();
builder.Services.AddDbExtensions();
builder.Services.AddWebExtensions();
builder.Services.AddControllersWithViews();

// Configure Application

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.UseWebOptimizer();

app.MapGet("/", () => Results.Redirect("/home"));
app.MapDefaultControllerRoute()
    .WithStaticAssets();

app.Run();