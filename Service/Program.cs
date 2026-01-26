using DotNetEnv;
using htmx_test.Data.Extensions;

Env.Load();

// Configure Services

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);
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

app.MapControllerRoute(
        name: "default",
        pattern: "Home/{controller=Todo}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();