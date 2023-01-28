using Microsoft.AspNetCore.Identity;

namespace WhatToDo.Domain.Entities;

public class AppUser : IdentityUser<int>
{
    public List<Activity>? Activities { get; set; }
}