using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatToDo.Logic.Services.ActivityService;
using WhatToDo.Logic.Services.ActivityService.Dtos;

namespace WhatToDo.Controllers;

[ApiController]
[Route("api/activity")]
public class ActivityController : ControllerBase
{
    private readonly IActivityService _activityService;

    public ActivityController(IActivityService activityService)
    {
        _activityService = activityService;
    }

    [HttpGet]
    public async Task<ActivityDto?> GetActivity()
    {
        return await _activityService.GetActivity();
    }
    
    [HttpGet("{type}")]
    public async Task<ActivityDto?> GetActivity(string type)
    {
        return await _activityService.GetActivityByType(type);
    }
    
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddActivity(ActivityDto activityDto)
    { 
        await _activityService.SaveActivity(activityDto);
        
        return Ok();
    }
    
    [Authorize]
    [HttpGet("my")]
    public async Task<List<ActivityDto>?> GetMyActivities()
    {
        return await _activityService.GetMyActivities();
    }
}