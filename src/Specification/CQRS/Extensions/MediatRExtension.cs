using MediatR;
using System.Reflection;

namespace CQRS.Extensions;

public static class MediatRExtension
{
    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
