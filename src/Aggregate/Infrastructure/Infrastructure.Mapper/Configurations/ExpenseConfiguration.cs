using AutoMapper;
using Domain.Dto;
using Domain.Entity;

namespace Infrastructure.Mapper.Configurations;

public static class ExpenseConfiguration
{
    public static IMapperConfigurationExpression AddExpenseDto(this IMapperConfigurationExpression cfg)
    {
        cfg.CreateMap<Expense, ExpenseDto>();
        return cfg;
    }
}
