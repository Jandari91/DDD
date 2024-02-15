using Domain.ValueObject;

namespace Domain.Dto;

public record CircleMemberDto(long CircleId, string CircleName, IEnumerable<Member> CircleMembers);
