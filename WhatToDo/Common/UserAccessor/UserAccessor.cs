using System.Security.Claims;
using WhatToDo.Logic.Common.UserAccessor;

namespace WhatToDo.Common.UserAccessor;

public class UserAccessor : IUserAccessor
{
    private readonly IHttpContextAccessor _contextAccessor;

    public UserAccessor(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor ?? throw new ArgumentException();
    }

    public ClaimsPrincipal User => _contextAccessor.HttpContext.User;
    
    public int UserId => int.Parse(User.Identity.Name);
}