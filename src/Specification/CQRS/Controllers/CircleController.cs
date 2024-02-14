using CQRS.Core.Application.Features.Circle.Queries;
using Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.Controllers;

[ApiController]
[Route("[controller]")]
public class CircleController : ControllerBase
{
    private readonly ILogger<CircleController> _logger;
    private readonly IMediator _mediator;
    public CircleController(
        ILogger<CircleController> logger,
        IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet("/recommendcircle", Name = "GetRecommendCircle")]
    public async Task<IEnumerable<CircleDto>> GetRecommend() => await _mediator.Send(new GetRecommendCircleQuery());
    
}
