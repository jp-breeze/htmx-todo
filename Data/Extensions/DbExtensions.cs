using htmx_todo.Data.Todos;
using htmx_todo.Domain.Todos;
using Microsoft.Extensions.DependencyInjection;

namespace htmx_todo.Data.Extensions;

public static class DbExtensions
{
    public static void AddDbExtensions(this IServiceCollection services)
    {
        // Only adding as a singleton because Todos are stored in-memory within this repository.
        services.AddSingleton<ITodoRepository, TodoRepository>();
    }
}