using Specification.Core.Application.Persistences;
using Specification.Core.Application.Service;
using Specification.Core.Domain.Command;
using Specification.Core.Domain.Exception;

namespace Specification.Service;

public class CircleApplicationService : ICircleApplicationService
{
    private readonly ICircleRepository circleRepository;
    private readonly IUserRepository userRepository;

    public CircleApplicationService(ICircleRepository circleRepository, IUserRepository userRepository)
    {
        this.circleRepository = circleRepository;
        this.userRepository = userRepository;
    }

    public async void Join(CircleJoinCommand command)
    {
        var circleId = command.CircleId;
        var circle = await circleRepository.GetAsync(circleId);
        var members = circle.Users;
        var premiumUserNumber = members.Count(user => user.IsPremium);
        var circleUpperLimit = premiumUserNumber < 10 ? 30 : 50;
        if(circle.CountMembers() >= circleUpperLimit)
        {
            throw new CircleFullException(circleId);
        }

        var newMember = await userRepository.GetAsync(command.UserId);
        circle.Users.Add(newMember);
        await circleRepository.UpdateAsync(circle);
    }
}
