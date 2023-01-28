using Microsoft.AspNetCore.Mvc;
using WhatToDo.Logic.Services.AccountService;
using WhatToDo.Logic.Services.AccountService.Dtos;

namespace WhatToDo.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<int> Register(RegisterDto registerDto)
    {
        return await _accountService.Register(registerDto);
    }
    
    [HttpPost("login")]
    public async Task<string> Login(LoginDto loginDto)
    {
        return await _accountService.Login(loginDto);
    }
}