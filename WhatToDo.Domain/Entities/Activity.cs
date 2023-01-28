namespace WhatToDo.Domain.Entities;

public class Activity
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public AppUser User { get; set; }
    
    public string Text { get; set; }

    public string Type { get; set; }

    public double Accessibility { get; set; }

    public int Participants { get; set; }

    public double Price { get; set; }
}