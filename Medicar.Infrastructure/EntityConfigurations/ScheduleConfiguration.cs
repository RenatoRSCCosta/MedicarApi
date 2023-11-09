using Medicar_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Infrastructure.EntityConfigurations;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.HasKey(s => s.ScheduleId);

        builder.HasMany(s => s.Slots)
            .WithOne(s => s.Schedule)
            .HasForeignKey(s => s.ScheduleId);

        builder.HasMany(s => s.Consultations)
            .WithOne(c => c.Schedule)
            .HasForeignKey(c => c.ScheduleId);

        builder.Property(s => s.Date)
            .HasColumnType("date");
    }
}
