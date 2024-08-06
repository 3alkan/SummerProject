using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Concrete;

namespace Project.DataAccess.Configurations
{
    public class WillWatchedFilmConfiguration : IEntityTypeConfiguration<WillWatchedFilm>
    {
        public void Configure(EntityTypeBuilder<WillWatchedFilm> builder)
        {
            // Define composite primary key
            builder.HasKey(wf => new { wf.UserId, wf.FilmId });

            // Configure properties
            builder.Property(wf => wf.DateAdded)
                .IsRequired();

            // Configure relationships
            builder.HasOne(wf => wf.User)
                .WithMany(u => u.WatchList)
                .HasForeignKey(wf => wf.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(wf => wf.Film)
                .WithMany() // No navigation property in Film entity
                .HasForeignKey(wf => wf.FilmId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
