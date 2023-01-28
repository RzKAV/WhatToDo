using WhatToDo.Domain.Entities;

namespace WhatToDo.Logic.Services.TokenService;

public interface ITokenService
{
    string CreateAccessToken(AppUser appUser);
}