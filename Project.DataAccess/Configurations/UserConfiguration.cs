using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Concrete;

namespace Project.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Define primary key
            builder.HasKey(u => u.UserId);

            // Configure properties
            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255);

            // Configure relationships
            builder.HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.WatchList)
                .WithOne(willWatchedFilm => willWatchedFilm.User)
                .HasForeignKey(willWatchedFilm => willWatchedFilm.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.WatchedFilms)
                .WithOne(watchedFilm => watchedFilm.User)
                .HasForeignKey(watchedFilm => watchedFilm.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
