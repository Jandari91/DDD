using Infrastructure.Mapper.AutoMappers;
namespace Aggregate.Extensions;

public static class MapperExtension
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper();
        return services;
    }
}

