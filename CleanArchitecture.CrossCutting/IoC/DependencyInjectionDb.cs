using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Infrastructure.Context;

namespace CleanArchitecture.CrossCutting.IoC;

public static class DependencyInjectionDb
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration config)
    {
        // Build connection string from environment variables
        var host = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
        var database = Environment.GetEnvironmentVariable("DB_NAME") ?? "CleanArchitectureDb";
        var username = Environment.GetEnvironmentVariable("DB_USER") ?? "postgres";
        var password = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "";
        var port = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
        
        var connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}
