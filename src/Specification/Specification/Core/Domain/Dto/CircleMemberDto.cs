using Specification.Core.Domain.ValueObject;

namespace Specification.Core.Domain.Dto;

public class CircleMemberDto
{
    public long CircleId { get; set; }
    public string CircleName { get; set; }
    public IEnumerable<Member> Members { get; set; } = new List<Member>();
    public CircleMemberDto(long circleId, string circleName, IEnumerable<Member> members)
    {
        CircleId = circleId;
        CircleName = circleName;
        Members = members;
    }
}