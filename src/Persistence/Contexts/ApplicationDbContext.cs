using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<DaysTally> DaysTallies { get; set; }
        public DbSet<PublicHoliday> PublicHolidays { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<HubConfigurationEntry> HubConfigurationEntries { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Team>().HasData(
                new Team() { Id = 1, Name = "Team1" },
                new Team() { Id = 2, Name = "Team2" }
                );

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "3659f040-51a9-496a-958d-7030a439012e", Name = "TeamLead", NormalizedName = "TEAMLEAD" },
                new IdentityRole { Id = "60024229-fb65-490d-abfd-f1369a56f952", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "6e875cce-3fc3-4ad3-87f5-9672ddeaa099", Name = "RegularEmployee", NormalizedName = "REGULAREMPLOYEE" }
                );

            builder.Entity<HubConfigurationEntry>().HasData(
                new HubConfigurationEntry { Id = 1, Name = "AnnualLeaveDays", Value = "20" }
                );
        }

    }
}
