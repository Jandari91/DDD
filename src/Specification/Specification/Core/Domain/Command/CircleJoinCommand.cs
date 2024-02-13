namespace Specification.Core.Domain.Command;

//public record CircleJoinCommand(long CircleId, long UserId);
public class CircleJoinCommand
{

    public long CircleId { get; set; }
    public long UserId { get; set; }
    public CircleJoinCommand(long circleId, long userId)
    {
        CircleId = circleId;
        UserId = userId;
    }
}