using WhatToDo.Logic.Services.AccountService.Dtos;

namespace WhatToDo.Logic.Services.AccountService;

public interface IAccountService
{
    Task<string> Login(LoginDto loginDto);

    Task<int> Register(RegisterDto registerDto);
}