using Domain.Exception;

namespace Domain.Entity;

public class Activity : BaseEntity
{
    public string Title { get; set; } = default!;
    public long CircleId { get; set; } = default!;
    public float TotalExpense { get; set; } = default!;
    public Circle Circle { get; } = default!;
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public Activity(string title, long circleId)
    {
        if (string.IsNullOrEmpty(title)) throw new DomainException($"{nameof(title)} is empty.");
        if (circleId <= 0) throw new DomainException($"Invalid circleId: '{nameof(circleId)}'. Circle Id must be a positive number.");
        this.Title = title;
        this.CircleId = circleId;
    }

    public Expense AddExpense(Expense expense)
    {
        this.Expenses.Add(expense);
        TotalExpense = GetTotalExpense();
        return expense;
    }

    public void RemoveExpense(long expenseId)
    {
        var target = this.Expenses.Where(x => x.Id == expenseId).FirstOrDefault();
        if (target == null)
            throw new DomainException("Expense with the specified ID not found");
        Expenses.Remove(target);
        TotalExpense = GetTotalExpense();
    }

    public Expense UpdateExpense(Expense expense)
    {
        var target = this.Expenses.Where(x => x.Id == expense.Id).FirstOrDefault();
        if (target == null)
            throw new DomainException("Expense with the specified ID not found");
        target = expense;
        Expenses.Remove(target);
        TotalExpense = GetTotalExpense();
        return target;
    }

    private float GetTotalExpense() => Expenses.Sum(e => e.Payment);
}
