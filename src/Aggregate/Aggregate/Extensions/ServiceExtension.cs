using Aggregate.Core.Application.Service;
using Aggregate.Service;

namespace Aggregate.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<ICircleApplicationService, CircleApplicationService>();

        return services;
    }
}
