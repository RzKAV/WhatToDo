using Microsoft.AspNetCore.Identity;
using WhatToDo.Domain.Entities;
using WhatToDo.Logic.Services.AccountService.Dtos;
using WhatToDo.Logic.Services.TokenService;

namespace WhatToDo.Logic.Services.AccountService;

internal class AccountService : IAccountService
{
    private readonly ITokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;

    public AccountService(ITokenService tokenService, UserManager<AppUser> userManager)
    {
        _tokenService = tokenService;
        _userManager = userManager;
    }

    public async Task<string> Login(LoginDto loginDto)
    {
        if (string.IsNullOrWhiteSpace(loginDto.UserName))
        {
            throw new ArgumentException(nameof(loginDto.UserName));
        }

        var user = await _userManager.FindByNameAsync(loginDto.UserName);

        if (user == null ||
            !await _userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            throw new Exception("Incorrect password");
        }

        return _tokenService.CreateAccessToken(user);
    }

    public async Task<int> Register(RegisterDto registerDto)
    {
        if (string.IsNullOrWhiteSpace(registerDto.UserName) ||
            string.IsNullOrWhiteSpace(registerDto.Email))
        {
            throw new ArgumentException(nameof(registerDto));
        }

        var user = new AppUser
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email
        };

        var createResult = await _userManager.CreateAsync(user, registerDto.Password);

        if (!createResult.Succeeded)
        {
            throw new ArgumentException(nameof(registerDto));
        }

        return user.Id;
    }
}