using Microsoft.Extensions.DependencyInjection;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Repositories;

namespace CleanArchitecture.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            typeof(CleanArchitecture.Application.DTOs.Users.CreateUserRequestDto).Assembly
        ));
        
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
