using WhatToDo.Logic.Services.ActivityService.Dtos;

namespace WhatToDo.Logic.Services.ActivityService;

public interface IActivityService
{
    Task<ActivityDto?> GetActivity();

    Task<ActivityDto?> GetActivityByType(string type);

    Task SaveActivity(ActivityDto activityDto);

    Task<List<ActivityDto>?> GetMyActivities();
}