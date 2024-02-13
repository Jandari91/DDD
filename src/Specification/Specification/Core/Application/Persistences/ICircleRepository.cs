using Specification.Core.Application.Specification;
using Specification.Core.Domain.Entity;
namespace Specification.Core.Application.Persistences
{
    public interface ICircleRepository : IBaseRepository<Circle>
    {
        public Task<IEnumerable<Circle>> GetRecommendCircle(Specification<Circle> specification);
    }
}
