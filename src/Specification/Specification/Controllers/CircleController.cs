using Application.Mapper;
using Application.Persistences;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Specification.Core.Application.Service;

namespace Specification.Controllers;

[ApiController]
[Route("[controller]")]
public class CircleController : ControllerBase
{
    private readonly ILogger<CircleController> _logger;
    private readonly ICircleRepository _circleRepository;
    private readonly ICircleApplicationService _circleApplicationService;
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
        _circleApplicationService = circleApplicationService;
        _mapper = mapper;
    }

    [HttpGet("/circles",Name = "GetCircles")]
    public async Task<IEnumerable<CircleDto>> Get()
    {
        var circles = await _circleRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CircleDto>>(circles);
    }

    [HttpGet("/recommendcircle", Name = "GetRecommendCircle")]
    public async Task<IEnumerable<CircleDto>> GetRecommend()
    {
        var circles = await _circleApplicationService.GetRecommend();
        return _mapper.Map<IEnumerable<CircleDto>>(circles);
    }
}
