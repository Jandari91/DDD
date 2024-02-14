using AutoMapper;
using Domain.Dto;
using Domain.Entity;
using Domain.ValueObject;

namespace Specification.Infrastructure.Mapper.Configurations;


public static class CircleMemberConfiguration
{
    public static IMapperConfigurationExpression AddCircleMemberDto(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<Circle, CircleMemberDto>()
            .ConstructUsing(e => new CircleMemberDto(e.Id, e.Name, e.Users.Select(m => new Member(m.Id, m.Name))));
        return cfg;
    }
}
