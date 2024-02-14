using Domain.Entity;
using Aggregate.Core.Domain.Command;

namespace Aggregate.Core.Application.Service;

public interface ICircleApplicationService
{
    public Task Join(CircleJoinCommand command);
    public Task<IEnumerable<Circle>> GetRecommend();
}
