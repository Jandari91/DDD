using Specification.Core.Application.Specification;
using Specification.Core.Domain.Entity;
using System.Linq.Expressions;

namespace Specification.Specification
{
    public class CircleRecommendSpecification : Specification<Circle>
    {
        private readonly DateTime _executeDateTime;
        public CircleRecommendSpecification(DateTime executeDateTime)
        {
            _executeDateTime = executeDateTime;
        }

        public override Expression<Func<Circle, bool>> ToExpression()
        {
            return circle => circle.Created > _executeDateTime.AddMonths(1);
        }
    }
}
