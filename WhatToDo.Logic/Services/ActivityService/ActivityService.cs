using Microsoft.EntityFrameworkCore;
using WhatToDo.Domain.Entities;
using WhatToDo.Logic.Common.ExternalServices;
using WhatToDo.Logic.Common.UserAccessor;
using WhatToDo.Logic.Services.ActivityService.Dtos;

namespace WhatToDo.Logic.Services.ActivityService;

internal class ActivityService : IActivityService
{
    private readonly IBoredApiClient _apiClient;
    private readonly AppDbContext _dbContext;
    private readonly IUserAccessor _userAccessor;

    public ActivityService(IBoredApiClient apiClient,
        AppDbContext dbContext,
        IUserAccessor userAccessor)
    {
        _apiClient = apiClient;
        _dbContext = dbContext;
        _userAccessor = userAccessor;
    }

    public async Task<ActivityDto?> GetActivity()
    {
        return await _apiClient.GetActivity();
    }

    public async Task<ActivityDto?> GetActivityByType(string type)
    {
        return await _apiClient.GetActivityByType(type);
    }

    public async Task SaveActivity(ActivityDto activityDto)
    {
        if (activityDto == null)
        {
            throw new ArgumentException(nameof(activityDto));
        }

        var activity = new Activity
        {
            Text = activityDto.Text,
            Type = activityDto.Type,
            Accessibility = activityDto.Accessibility,
            Participants = activityDto.Participants,
            Price = activityDto.Price,
            UserId = _userAccessor.UserId
        };

        _dbContext.Activities.Add(activity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<ActivityDto>?> GetMyActivities()
    {
        return await _dbContext.Activities
            .Where(activity => activity.UserId == _userAccessor.UserId)
            .Select(activity => new ActivityDto
            {
                Text = activity.Text,
                Type = activity.Type,
                Accessibility = activity.Accessibility,
                Participants = activity.Participants,
                Price = activity.Price,
            }).ToListAsync();
    }
}