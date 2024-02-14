namespace Domain.Entity;

public class User : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public int Age { get; set; } = default!;
    public bool IsPremium { get; set; } = default!;
    public List<Circle> Circles { get; set; } = new();
}
