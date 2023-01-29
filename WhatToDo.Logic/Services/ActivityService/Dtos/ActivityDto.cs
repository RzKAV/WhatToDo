using System.Text.Json.Serialization;

namespace WhatToDo.Logic.Services.ActivityService.Dtos;

public class ActivityDto
{
    [JsonPropertyName("activity")]
    public string Text { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("accessibility")]
    public double Accessibility { get; set; }

    [JsonPropertyName("participants")]
    public int Participants { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }
}