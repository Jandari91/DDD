using Specification.Core.Application.Persistences;
using Specification.Core.Application.Specification;
using Specification.Core.Domain.Entity;
using System.Linq.Expressions;

namespace Specification.Specification;

public class CircleFullSpecification : Specification<Circle>
{
    
    public override Expression<Func<Circle, bool>> ToExpression()
    {
        return circle => circle.CountMembers() >= GetCircleUpperLimit(circle);
    }

    private int GetCircleUpperLimit(Circle circle)
    {
        var members = circle.Users;
        var premiumUserNumber = members.Count(user => user.IsPremium);
        return premiumUserNumber < 1 ? 3 : 5;
    }
}
