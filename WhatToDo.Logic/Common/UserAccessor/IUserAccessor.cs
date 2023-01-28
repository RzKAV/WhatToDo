using System.Security.Claims;

namespace WhatToDo.Logic.Common.UserAccessor;

public interface IUserAccessor
{
    public ClaimsPrincipal User { get; }

    public int UserId { get; }
}