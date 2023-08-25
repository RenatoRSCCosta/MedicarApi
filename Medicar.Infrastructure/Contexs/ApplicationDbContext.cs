using Medicar_API.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Medicar.Infrastructure.Contexs
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts) : base(opts)
        {
            
        }

        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<Specialty> Specialtys { get; set; }

    }
}
