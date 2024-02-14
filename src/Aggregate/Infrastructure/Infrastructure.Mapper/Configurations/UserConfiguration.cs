using AutoMapper;
using Domain.Dto;
using Domain.Entity;

namespace Aggregate.Infrastructure.Mapper.Configurations;

public static class UserConfiguration
{
    public static IMapperConfigurationExpression AddUserDto(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<User, UserDto>();
        return cfg;
    }
}
