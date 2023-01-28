using System.Net.Http.Json;
using WhatToDo.Logic.Common.ExternalServices;
using WhatToDo.Logic.Services.ActivityService.Dtos;

namespace WhatToDo.Infrastructure.Services;

internal class BoredApiClient : IBoredApiClient
{
    private readonly IHttpClientFactory _httpClientFactory;

    public BoredApiClient(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ActivityDto?> GetActivity()
    {
        var client = _httpClientFactory.CreateClient("BoredApi");
        
        var result = await client.GetFromJsonAsync<TempActivity>($"activity");
        
        return new ActivityDto
        {
            Text = result.activity,
            Type = result.type,
            Accessibility = result.accessibility,
            Participants = result.participants,
            Price = result.price
        };
    }

    public async Task<ActivityDto?> GetActivityByType(string type)
    {
        var client = _httpClientFactory.CreateClient("BoredApi");
        
        var result = await client.GetFromJsonAsync<TempActivity>($"activity?type={type}");

        return new ActivityDto
        {
            Text = result.activity,
            Type = result.type,
            Accessibility = result.accessibility,
            Participants = result.participants,
            Price = result.price
        };
    }
}