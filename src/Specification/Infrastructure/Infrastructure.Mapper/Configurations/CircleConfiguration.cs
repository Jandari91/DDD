using AutoMapper;
using Domain.Dto;
using Domain.Entity;

namespace Specification.Infrastructure.Mapper.Configurations;

public static class CircleConfiguration
{
    public static IMapperConfigurationExpression AddCircleDto(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<Circle, CircleDto>();
        return cfg;
    }
}
