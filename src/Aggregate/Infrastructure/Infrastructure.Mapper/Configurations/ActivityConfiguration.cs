using AutoMapper;
using Domain.Dto;
using Domain.Entity;

namespace Infrastructure.Mapper.Configurations;

public static class ActivityConfiguration
{
    public static IMapperConfigurationExpression AddActivityDto(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<Activity, ActivityDto>()
            .ConstructUsing(e => new ActivityDto(e.Id, e.CircleId, e.Title, e.TotalExpense, e.Expenses.Select(m => new Domain.ValueObject.ExpenseVo(m.Title, m.Payment))));
        return cfg;
    }
}
