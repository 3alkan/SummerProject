using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Project.DataAccess.Concrete
{
    public class FilmContextFactory : IDesignTimeDbContextFactory<FilmContext>
    {
        public FilmContext CreateDbContext(string[] args)
        {
            // Build configuration
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Project.App");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json")
                .Build();

            // Create options builder
            var optionsBuilder = new DbContextOptionsBuilder<FilmContext>();
            optionsBuilder.UseSqlite(configuration.GetConnectionString("FilmDbFactory"));

            // Create and return context
            return new FilmContext(optionsBuilder.Options);
        }
    }
}
