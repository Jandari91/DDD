using Microsoft.AspNetCore.Mvc;
using Specification.Core.Application.Mapper;
using Specification.Core.Application.Persistences;
using Specification.Core.Domain.Dto;

namespace Specification.Controllers;

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
        IMapper mapper
        )
    {
        _logger = logger;
        _circleRepository = circleRepository;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetCircles")]
    public async Task<IEnumerable<CircleDto>> Get()
    {
        var users = await _circleRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CircleDto>>(users);
    }
}
