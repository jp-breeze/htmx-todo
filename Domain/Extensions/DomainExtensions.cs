using htmx_todo.Domain.Todos;
using Microsoft.Extensions.DependencyInjection;

namespace htmx_todo.Domain.Extensions;

public static class DomainExtensions
{
    public static void AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<TodoService>();
    }
}