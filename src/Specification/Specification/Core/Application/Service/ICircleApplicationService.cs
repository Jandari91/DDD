using Specification.Core.Domain.Command;

namespace Specification.Core.Application.Service;

public interface ICircleApplicationService
{
    public void Join(CircleJoinCommand command);
}
