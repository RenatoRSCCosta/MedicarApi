using Medicar_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicar.Infrastructure.EntityConfigurations;

public class ConsultationConfiguration : IEntityTypeConfiguration<Consultation>
{
    public void Configure(EntityTypeBuilder<Consultation> builder)
    {
        builder.HasKey(c => c.ConsultationId);

        builder.HasIndex(c => new {c.SlotId, c.ScheduleId})
            .IsUnique();

        builder.HasOne(c => c.Schedule)
            .WithMany(s => s.Consultations)
            .HasForeignKey(c => c.ScheduleId);

        builder.HasOne(c => c.Slot)
            .WithMany(s => s.Consultations)
            .HasForeignKey(c => c.SlotId);
    }
}
