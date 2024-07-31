using Microsoft.EntityFrameworkCore;
using Project.Entities.Concrete;
using System.IO;

namespace Project.DataAccess.Concrete
{
    public class FilmContext : DbContext
    {
        public DbSet<Film> Films { get; set; }

        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Film entity using Fluent API if needed later
        }
    }
}
