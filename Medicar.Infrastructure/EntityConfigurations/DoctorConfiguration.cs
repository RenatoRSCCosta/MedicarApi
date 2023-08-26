using Medicar_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Medicar.Infrastructure.EntityConfigurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(p => p.DoctorId);

        builder.Property(p => p.Name)
            .HasColumnType("varchar")
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(p => p.Crm)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(c => c.Crm)
            .IsUnique();

        builder.Property(p => p.Email)
            .HasColumnType("varchar")
            .HasMaxLength(50);
    }
}
