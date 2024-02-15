namespace Domain.Entity;

public class Circle : BaseEntity
{
    public string Name { get; set; } = default!;

    public List<User> Members { get; } = new();
    public List<Activity> Activies { get; } = new();

    public int CountMembers() => Members.Count;
    public bool IsFull() => CountMembers() >= 30;
}
