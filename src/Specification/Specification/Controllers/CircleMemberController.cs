using Microsoft.AspNetCore.Mvc;
using Specification.Core.Application.Mapper;
using Specification.Core.Application.Persistences;
using Specification.Core.Application.Service;
using Specification.Core.Domain.Command;
using Specification.Core.Domain.Dto;

namespace Specification.Controllers;

[ApiController]
[Route("[controller]")]
public class CircleMemberController : ControllerBase
{
    private readonly ILogger<CircleMemberController> _logger;
    private readonly ICircleRepository _circleRepository;
    private readonly ICircleApplicationService _circleApplicationService; 
    private readonly IMapper _mapper;
    public CircleMemberController(
        ILogger<CircleMemberController> logger,
        ICircleApplicationService circleApplicationService,
        ICircleRepository circleRepository,
        IMapper mapper
        )
    {
        _logger = logger;
        _circleApplicationService = circleApplicationService;
        _circleRepository = circleRepository;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetCircleMembers")]
    public async Task<IEnumerable<CircleMemberDto>> Get()
    {
        var users = await _circleRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CircleMemberDto>>(users);
    }

    [HttpPost(Name = "AddCircleMember")]
    public async Task<bool> Add(CircleJoinCommand command)
    {
        try
        {
            await _circleApplicationService.Join(command);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
