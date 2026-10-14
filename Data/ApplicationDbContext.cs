using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Race_System_2_.Models;

namespace Race_System_2_.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Custom Part 1 database tables
        public DbSet<Event> Events { get; set; }
        public DbSet<RaceCategory> RaceCategories { get; set; }
        public DbSet<EventRace> EventRaces { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Result> Results { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Add any custom entity configurations or seed data here if needed
        }
    }
}