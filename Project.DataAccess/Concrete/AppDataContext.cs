using Microsoft.EntityFrameworkCore;
using Project.Entities.Concrete;
using System.IO;

namespace Project.DataAccess.Concrete
{
    public class AppDataContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<User> Users{ get; set; }

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Film entity using Fluent API if needed later
        }
    }
}
