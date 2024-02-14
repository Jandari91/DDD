using Application.Persistences;
using Domain.Entity;
using Domain.Exception;
using Aggregate.Core.Application.Service;
using Aggregate.Core.Domain.Command;

namespace Aggregate.Service;

public class CircleApplicationService : ICircleApplicationService
{
    private readonly ICircleRepository circleRepository;
    private readonly IUserRepository userRepository;

    public CircleApplicationService(ICircleRepository circleRepository, IUserRepository userRepository)
    {
        this.circleRepository = circleRepository;
        this.userRepository = userRepository;
    }

    public Task<IEnumerable<Circle>> GetRecommend()
    {
        throw new NotImplementedException();
    }

    public async Task Join(CircleJoinCommand command)
    {
        var circleId = command.CircleId;
        var circle = await circleRepository.GetAsync(circleId);
        var members = circle.Members;
        var premiumUserNumber = members.Count(user => user.IsPremium);
        var circleUpperLimit = premiumUserNumber < 1 ? 3 : 5;
        if(circle.CountMembers() >= circleUpperLimit)
        {
            throw new CircleFullException(circleId);
        }

        var newMember = await userRepository.GetAsync(command.UserId);
        circle.Members.Add(newMember);
        await circleRepository.UpdateAsync(circle);
    }
}
