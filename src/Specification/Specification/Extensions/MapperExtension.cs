using Infrastructure.Mapper.AutoMappers;
namespace Specification.Extensions;

public static class MapperExtension
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddAutoMapper();
        return services;
    }
}

