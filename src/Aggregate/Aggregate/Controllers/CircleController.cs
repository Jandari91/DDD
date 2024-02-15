using Aggregate.Core.Application.Service;
using Application.Mapper;
using Application.Persistences;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Aggregate.Controllers;

[ApiController]
[Route("[controller]")]
public class CircleController : ControllerBase
{
    private readonly ILogger<CircleController> _logger;
    private readonly ICircleRepository _circleRepository;
    private readonly IMapper _mapper;
    public CircleController(
        ILogger<CircleController> logger,
        ICircleRepository circleRepository,
        ICircleApplicationService circleApplicationService,
        IMapper mapper
        )
    {
        _logger = logger;
        _circleRepository = circleRepository;
        _mapper = mapper;
    }

    [HttpGet("/circles",Name = "GetCircles")]
    public async Task<IEnumerable<CircleDto>> Get()
    {
        var circles = await _circleRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CircleDto>>(circles);
    }
}
