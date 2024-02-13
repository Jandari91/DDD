using Specification.Core.Domain.Entity;
using System.Linq.Expressions;

namespace Specification.Core.Application.Specification;

public abstract class Specification<T> where T : BaseEntity
{
    public abstract Expression<Func<T, bool>> ToExpression();

    public bool IsSatisfiedBy(T entity)
    {
        Func<T, bool> predicate = ToExpression().Compile();
        return predicate(entity);
    }
}