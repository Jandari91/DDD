using Domain.ValueObject;

namespace Domain.Dto;

public class ActivityDto
{
    public long Id { get; set; }
    public long CircleId { get; set; }
    public string Title { get; set; } = default!;
    public float TotalExpense { get; set; }
    public IEnumerable<ExpenseVo> ExpenseList { get; set; } = new List<ExpenseVo>();

    public ActivityDto(long id, long circleId, string title, float totalExpense, IEnumerable<ExpenseVo> expenseList)
    {
        Id = id;
        CircleId = circleId;
        Title = title;
        TotalExpense = totalExpense;
        ExpenseList = expenseList;
    }
}
