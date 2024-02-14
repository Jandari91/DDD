using Specification.Core.Domain.Command;
using Specification.Core.Domain.Entity;

namespace Specification.Core.Application.Service;

public interface ICircleApplicationService
{
    public Task Join(CircleJoinCommand command);
    public Task<IEnumerable<Circle>> GetRecommend();
}
