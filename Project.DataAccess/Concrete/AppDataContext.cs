using Microsoft.EntityFrameworkCore;
using Project.Entities.Concrete;
using Project.DataAccess.Configurations;

namespace Project.DataAccess.Concrete
{
    public class AppDataContext : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WatchedFilm> WatchedFilms { get; set; }
        public DbSet<WillWatchedFilm> WillWatchedFilms { get; set; }

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply configurations
            modelBuilder.ApplyConfiguration(new FilmConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new DirectorConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new WatchedFilmConfiguration());
            modelBuilder.ApplyConfiguration(new WillWatchedFilmConfiguration());
        }
    }
}
