using Medicar_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Medicar.Infrastructure.Contexs
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var types = modelBuilder.Model
            .GetEntityTypes()
            .Select(type => type.ClrType)
            .ToHashSet();

            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly(),
                type => type.GetInterfaces()
                .Any(interfaceType => interfaceType.IsGenericType
                                    && interfaceType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)
                                    && types.Contains(
                                    interfaceType.GenericTypeArguments[0])));
        }

        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Specialty> Specialtys { get; set; }
        public int PositionGenericTypeArguments { get; private set; }
    }
}
