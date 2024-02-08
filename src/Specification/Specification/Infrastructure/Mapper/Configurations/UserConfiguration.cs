using AutoMapper;
using Specification.Core.Domain.Dto;
using Specification.Core.Domain.Entity;

namespace Specification.Infrastructure.Mapper.Configurations;

public static class UserConfiguration
{
    public static IMapperConfigurationExpression AddUserDto(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<User, UserDto>();
        return cfg;
    }
}
