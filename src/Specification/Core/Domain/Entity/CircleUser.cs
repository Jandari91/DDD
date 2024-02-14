namespace Domain.Entity;
public class CircleUser
{
    public long CircleId { get; set; }
    public long UserId { get; set; }
    public Circle Circle { get; set; } = default!;
    public User User { get; set; } = default!;
}
