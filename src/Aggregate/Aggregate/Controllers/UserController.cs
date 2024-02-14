using Application.Mapper;
using Application.Persistences;
using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
namespace Aggregate.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserController(
        ILogger<UserController> logger,
        IUserRepository userRepository,
        IMapper mapper
        )
    {
        _logger = logger;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<IEnumerable<UserDto>> Get()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDto>>(users);
    }
}
