using System.Reflection;
using Infrastructure.EFCore;
namespace Specification.Extensions;

public static class PersistenceExtension
{
    public static IServiceCollection AddEFCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInMemory(Assembly.GetExecutingAssembly().GetName().Name!);

        return services;
    }
}
