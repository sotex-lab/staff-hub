using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence.Contexts
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            options.UseSqlServer(CONNECTION_STRING);

            return new ApplicationDbContext(options.Options);
        }

        public static string CONNECTION_STRING => Environment.GetEnvironmentVariable("CONNECTION_STRING");
    }
}
