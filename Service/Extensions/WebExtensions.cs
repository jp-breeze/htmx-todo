namespace htmx_todo.Service.Extensions;

public static class WebExtensions
{
    public static void AddWebExtensions(this IServiceCollection services)
    {
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