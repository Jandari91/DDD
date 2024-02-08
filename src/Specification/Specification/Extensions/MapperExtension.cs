using Specification.Core.Application.Mapper;
using Specification.Infrastructure.Mapper;
using Specification.Infrastructure.Mapper.Configurations;

namespace Specification.Extensions;

public static class MapperExtension
{
    public static IServiceCollection AddMapper(this IServiceCollection services)
    {
        services.AddSingleton<IMapper, AutoMapperDI>();
        services.AddSingleton<AutoMapper.IMapper>(new AutoMapper.Mapper(MapperBuilder()));
        return services;
    }
    private static AutoMapper.MapperConfiguration MapperBuilder()
    {
        return new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddUserDto()
               .AddCircleDto()
               .AddCircleMemberDto();
        });
    }
}

