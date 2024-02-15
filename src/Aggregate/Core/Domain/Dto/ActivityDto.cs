using Domain.ValueObject;

namespace Domain.Dto;

public record ActivityDto(long Id, long CircleId, string Title, float TotalExpense, IEnumerable<ExpenseVo> ExpenseList);