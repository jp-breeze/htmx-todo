using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace htmx_test.Data.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbConnection>(_ => new NpgsqlConnection(configuration.GetConnectionString("DevDb")));
        
        return services;
    }
}