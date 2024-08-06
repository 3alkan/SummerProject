using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Concrete;

namespace Project.DataAccess.Configurations
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.HasKey(f => f.FilmId);

            builder.Property(f => f.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(f => f.Description)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(f => f.Year)
                .IsRequired();

            builder.Property(f => f.Time)
                .IsRequired();

            builder.HasOne(f => f.Director)
                .WithMany(d => d.Films)
                .HasForeignKey(f => f.DirectorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(f => f.Reviews)
                .WithOne(r => r.Film)
                .HasForeignKey(r => r.FilmId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(f=>f.Rate);
        }
    }
}
