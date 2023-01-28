using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhatToDo.Infrastructure.DataBase;
using WhatToDo.Infrastructure.Services;
using WhatToDo.Logic.Common.ExternalServices;

namespace WhatToDo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<MsSqlDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("MsSql"));
        });

        services.AddScoped<AppDbContext, MsSqlDbContext>();

        services.AddSingleton<IBoredApiClient, BoredApiClient>();
        
        services.AddHttpClient("BoredApi", client =>
        {
            client.BaseAddress = new Uri("https://www.boredapi.com/api/");
        });

        return services;
    }
}