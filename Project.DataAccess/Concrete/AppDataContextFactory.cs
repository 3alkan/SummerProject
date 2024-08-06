using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Project.DataAccess.Concrete
{
    public class AppDataContextFactory : IDesignTimeDbContextFactory<AppDataContext>
    {
        public AppDataContext CreateDbContext(string[] args)
        {
            // Build configuration
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Project.App");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Create options builder
            var optionsBuilder = new DbContextOptionsBuilder<AppDataContext>();
            optionsBuilder.UseSqlite(configuration.GetConnectionString("AppDataDbFactory"));

            // Create and return context
            return new AppDataContext(optionsBuilder.Options);
        }
    }
}
