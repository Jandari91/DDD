using Specification.Core.Application.Service;
using Specification.Service;
using Specification.Specification;

namespace Specification.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {

        services.AddTransient<ICircleApplicationService, CircleSpecApplicationService>();

        return services;
    }
}
