namespace Domain.Entity;

public class Expense : BaseEntity
{
    public string Title { get; set; } = default!;
    public float Payment { get; set; }
    public long ActivityId { get; set; }
    public Activity Activity { get; } = default!;
    public Expense(string title, float payment)
    {
        Title = title;
        Payment = payment;
    }
}
