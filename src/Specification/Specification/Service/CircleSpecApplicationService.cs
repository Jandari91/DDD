using Application.Persistences;
using Domain.Entity;
using Domain.Exception;
using Specification.Core.Application.Service;
using Specification.Core.Domain.Command;
using Specification.Specification;

namespace Specification.Service;

public class CircleSpecApplicationService : ICircleApplicationService
{
    private readonly ICircleRepository circleRepository;
    private readonly IUserRepository userRepository;

    public CircleSpecApplicationService(ICircleRepository circleRepository, IUserRepository userRepository)
    {
        this.circleRepository = circleRepository;
        this.userRepository = userRepository;
    }

    public async Task<IEnumerable<Circle>> GetRecommend()
    {
        var now = DateTime.UtcNow;
        var spec = new CircleRecommendSpecification(now);

        var circles = await circleRepository.GetAllAsync();
        var recommendCircles = circles
            .Where(spec.IsSatisfiedBy)
            .Take(10)
            .ToList();
        return recommendCircles;
    }

    public async Task Join(CircleJoinCommand command)
    {
        var circleId = command.CircleId;
        var circle = await circleRepository.GetAsync(circleId);

        var fullSpec = new CircleFullSpecification();
        if (fullSpec.IsSatisfiedBy(circle))
        {
            throw new CircleFullException(circleId);
        }

        var newMember = await userRepository.GetAsync(command.UserId);
        circle.Members.Add(newMember);
        await circleRepository.UpdateAsync(circle);
    }
}
