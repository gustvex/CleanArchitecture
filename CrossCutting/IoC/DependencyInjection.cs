using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces;
using Infrastructure.Repositories;

namespace CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            typeof(Application.DTOs.Users.CreateUserRequestDto).Assembly
        ));
        
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
