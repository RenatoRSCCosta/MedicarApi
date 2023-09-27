using Medicar_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medicar.Infrastructure.EntityConfigurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(d => d.DoctorId);

        builder.Property(d => d.Name)
            .HasColumnType("varchar")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(d => d.Crm)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(d => d.Crm)
            .IsUnique();

        builder.Property(d => d.Email)
            .HasColumnType("varchar")
            .HasMaxLength(50);

        builder.HasMany(d => d.Schedules)
            .WithOne(s => s.Doctor)
            .HasForeignKey(s => s.DoctorId);
    }
}
