using System.Net.Http.Json;
using WhatToDo.Logic.Common.ExternalServices;
using WhatToDo.Logic.Services.ActivityService.Dtos;

namespace WhatToDo.Infrastructure.Services;

internal class BoredApiClient : IBoredApiClient
{
    private readonly HttpClient _httpClient;
    public BoredApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        
        _httpClient.BaseAddress = new Uri("https://www.boredapi.com/api/");
    }

    public async Task<ActivityDto?> GetActivity()
    {
        return await _httpClient.GetFromJsonAsync<ActivityDto>(
            $"activity");;
    }

    public async Task<ActivityDto?> GetActivityByType(string type)
    {
        return await _httpClient.GetFromJsonAsync<ActivityDto>(
            $"activity?type={type}");;
    }
}