namespace Domain.ValueObject;

public class Member {
    public long UserId { get; set; }
    public string UserName { get; set; }
    public Member(long userId, string userName)
    {
        UserId = userId;
        UserName = userName;
    }
}