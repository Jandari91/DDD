using Domain.Entity;
using Specification.Core.Domain.Command;

namespace Specification.Core.Application.Service;

public interface ICircleApplicationService
{
    public Task Join(CircleJoinCommand command);
    public Task<IEnumerable<Circle>> GetRecommend();
}
