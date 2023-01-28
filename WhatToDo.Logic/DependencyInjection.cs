using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhatToDo.Logic.Common.AppConfig;
using WhatToDo.Logic.Services.AccountService;
using WhatToDo.Logic.Services.ActivityService;
using WhatToDo.Logic.Services.TokenService;

namespace WhatToDo.Logic;

public static class DependencyInjection
{
    public static IServiceCollection AddLogic(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.Configure<AuthOptions>(
            configuration.GetSection(nameof(AuthOptions)));
        
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IActivityService, ActivityService>();
        services.AddTransient<ITokenService, TokenService>();
        
        return services;
    }
}