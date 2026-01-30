using htmx_test.Domain.Todo;
using htmx_todo.Data.Todo;
using Microsoft.Extensions.DependencyInjection;

namespace htmx_todo.Data.Extensions;

public static class DbExtensions
{
    public static void AddDbExtensions(this IServiceCollection services)
    {
        services.AddScoped<ITodoRepository, TodoRepository>();
    }
}