using Microsoft.AspNetCore.Mvc.Razor;

namespace htmx_todo.Service.Extensions;

public static class WebExtensions
{
    public static void AddWebExtensions(this IServiceCollection services)
    {
        // Configure custom view location
        services.Configure<RazorViewEngineOptions>(options =>
        {
            options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
            options.ViewLocationFormats.Add("/Views/{1}/{0}.cshtml");
        });
        
        // Configure CSS location
        services.AddWebOptimizer(pipeline =>
        {
            pipeline.AddCssBundle(
                "/css/bundle.css",
                [
                    "css/reset.css",
                    "css/root.css",
                    "css/header.css",
                    "css/todo/*.css"
                ]
            );
        });
    }
}