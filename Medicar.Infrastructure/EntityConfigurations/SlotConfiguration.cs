using Medicar_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Infrastructure.EntityConfigurations;

public class SlotConfiguration : IEntityTypeConfiguration<Slot>
{
    public void Configure(EntityTypeBuilder<Slot> builder)
    {
        builder.HasKey(s => s.SlotId);

        builder.HasMany(s => s.Consultations)
            .WithOne(c => c.Slot)
            .HasForeignKey(c => c.SlotId);

        builder.Property(s => s.Hour)
            .HasColumnName("Hour")
            .HasColumnType("double precision")
            .HasPrecision(1);
    }
}
