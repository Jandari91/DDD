using Domain.Entity;
using Specification.Core.Application.Specification;
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
        var members = circle.Members;
        var premiumUserNumber = members.Count(user => user.IsPremium);
        return premiumUserNumber < 1 ? 3 : 5;
    }
}
