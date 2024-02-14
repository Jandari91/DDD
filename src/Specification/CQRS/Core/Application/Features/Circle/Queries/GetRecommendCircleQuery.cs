using Application.Mapper;
using Domain.Dto;
using Infrastructure.EFCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Core.Application.Features.Circle.Queries;

public record GetRecommendCircleQuery : IRequest<IEnumerable<CircleDto>>
{
}

public class GetRecommendCircleQueryHandler : IRequestHandler<GetRecommendCircleQuery, IEnumerable<CircleDto>>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetRecommendCircleQueryHandler(ApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CircleDto>> Handle(GetRecommendCircleQuery request, CancellationToken cancellationToken)
    {
        var now = DateTime.UtcNow;
        var circles = await _dbContext.Circles.Include(e => e.Members).Where(e => e.Created > now.AddMonths(-2)).Take(10).OrderBy(_ => _.Id).ToListAsync();
        return _mapper.Map<IEnumerable<CircleDto>>(circles);
    }
}
