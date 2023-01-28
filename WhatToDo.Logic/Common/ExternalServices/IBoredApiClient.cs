using WhatToDo.Logic.Services.ActivityService.Dtos;

namespace WhatToDo.Logic.Common.ExternalServices;

public interface IBoredApiClient
{
    Task<ActivityDto?> GetActivity();
    
    Task<ActivityDto?> GetActivityByType(string type);
}