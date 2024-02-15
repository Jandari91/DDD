using Microsoft.Extensions.DependencyInjection;
using Aggregate.Infrastructure.Mapper;
using Aggregate.Infrastructure.Mapper.Configurations;
using Infrastructure.Mapper.Configurations;

namespace Infrastructure.Mapper.AutoMappers;

public static class AutoMapperExtension
{
    public static IServiceCollection AddAutoMapper(this IServiceCollection services)
    {
        services.AddSingleton<Application.Mapper.IMapper, AutoMapperDI>();
        services.AddSingleton<AutoMapper.IMapper>(new AutoMapper.Mapper(MapperBuilder()));
        return services;
    }

    private static AutoMapper.MapperConfiguration MapperBuilder()
    {
        return new AutoMapper.MapperConfiguration(cfg =>
        {
            cfg.AddUserDto()
               .AddCircleDto()
               .AddCircleMemberDto()
               .AddActivityDto()
               .AddExpenseDto();
        });
    }
}
