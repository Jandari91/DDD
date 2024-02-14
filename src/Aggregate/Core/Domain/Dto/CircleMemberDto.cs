using Domain.ValueObject;

namespace Domain.Dto;

public class CircleMemberDto
{
    public long CircleId { get; set; }
    public string CircleName { get; set; }
    public IEnumerable<Member> CircleMembers { get; set; } = new List<Member>();
    public CircleMemberDto(long circleId, string circleName, IEnumerable<Member> members)
    {
        CircleId = circleId;
        CircleName = circleName;
        CircleMembers = members;
    }
}