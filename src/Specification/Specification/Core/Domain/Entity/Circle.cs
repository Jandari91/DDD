namespace Specification.Core.Domain.Entity;

public class Circle : BaseEntity
{
    public string Name { get; set; } = default!;

    public DateTime Created { get; set; }

    public List<User> Users { get; set; } = new();

    public int CountMembers() => Users.Count;
    public bool IsFull() => CountMembers() >= 30;
}
