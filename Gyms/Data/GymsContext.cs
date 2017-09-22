using Microsoft.EntityFrameworkCore;

namespace Gyms.Models
{
    public class GymsContext : DbContext
    {
        public GymsContext(DbContextOptions<GymsContext> options)
            : base(options)
        {
        }

        public DbSet<Gyms.Models.Client> Client { get; set; }

        public DbSet<Gyms.Models.Instructor> Instructor { get; set; }
        public DbSet<Gyms.Models.Class> Class { get; set; }
        public DbSet<Gyms.Models.ClassAttendance> ClassAttendance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<ClassAttendance>()
                .HasKey(c => new { c.ClassId, c.ClientId });
        }
    }
}
