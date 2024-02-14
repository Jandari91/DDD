using Application.Persistences;
using Infrastructure.EFCore.Repository;

namespace Specification.Extensions;

public static class RepositoryExtension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICircleRepository, CircleRepository>();

        return services;
    }
}
