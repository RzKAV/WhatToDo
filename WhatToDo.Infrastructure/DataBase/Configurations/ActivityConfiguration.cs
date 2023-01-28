using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhatToDo.Domain.Entities;

namespace WhatToDo.Infrastructure.DataBase.Configurations;

public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder
            .HasOne(activity => activity.User)
            .WithMany(user => user.Activities)
            .HasForeignKey(activity => activity.UserId);
    }
}