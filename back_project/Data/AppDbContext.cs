using back_project.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace back_project.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Journey> Routes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //if (!Database.CanConnect())
            //    Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
