using Aggregate.Core.Domain.Command;
using Application.Mapper;
using Application.Persistences;
using Domain.Dto;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Aggregate.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivityController : ControllerBase
{
    private readonly ILogger<CircleController> _logger;
    private readonly IActivityRepository _activityRepository;
    private readonly IMapper _mapper;
    public ActivityController(
        ILogger<CircleController> logger,
        IActivityRepository activityRepository,
        IMapper mapper
        )
    {
        _logger = logger;
        _activityRepository = activityRepository;
        _mapper = mapper;
    }

    [HttpGet("/activity", Name = "GetActivites")]
    public async Task<IEnumerable<ActivityDto>> Get()
    {
        var circles = await _activityRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ActivityDto>>(circles);
    }

    [HttpPost("/activity",Name = "AddActivity")]
    public async Task<ActivityDto> AddActivity(ActivityAddCommand command)
    {
        var newActivity = new Activity(command.Title, command.CircleId);
        var activity = await _activityRepository.CreateAsync(newActivity);
        return _mapper.Map<ActivityDto>(activity);
    }

    [HttpPost("/expense", Name = "AddExpense")]
    public async Task<ExpenseDto> AddExpense(ExpenseAddCommand command)
    {
        var activity = await _activityRepository.GetAsync(command.ActivityId);
        var newExpense = activity.AddExpense(new Expense(command.Title, command.Payment));
        await _activityRepository.UpdateAsync(activity);

        return _mapper.Map<ExpenseDto>(newExpense);
    }
}
