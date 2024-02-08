using Microsoft.AspNetCore.Mvc;
using Specification.Core.Application.Mapper;
using Specification.Core.Application.Persistences;
using Specification.Core.Domain.Dto;

namespace Specification.Controllers;

[ApiController]
[Route("[controller]")]
public class CircleMemberController : ControllerBase
{
    private readonly ILogger<CircleMemberController> _logger;
    private readonly ICircleRepository _circleRepository;
    private readonly IMapper _mapper;
    public CircleMemberController(
        ILogger<CircleMemberController> logger,
        ICircleRepository circleRepository,
        IMapper mapper
        )
    {
        _logger = logger;
        _circleRepository = circleRepository;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetCircleMembers")]
    public async Task<IEnumerable<CircleMemberDto>> Get()
    {
        var users = await _circleRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CircleMemberDto>>(users);
    }
}
