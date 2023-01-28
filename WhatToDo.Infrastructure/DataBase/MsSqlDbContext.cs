using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WhatToDo.Logic.Common.ExternalServices;

namespace WhatToDo.Infrastructure.DataBase;

internal class MsSqlDbContext : AppDbContext
{
    public MsSqlDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}