namespace Domain.Entity;

public class Circle : BaseEntity
{
    public string Name { get; set; } = default!;

    public DateTime Created { get; set; }

    public List<User> Members { get; } = new();

    public int CountMembers() => Members.Count;
    public bool IsFull() => CountMembers() >= 30;
}
