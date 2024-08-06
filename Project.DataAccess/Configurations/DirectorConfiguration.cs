using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Concrete;

namespace Project.DataAccess.Configurations
{
    public class DirectorConfiguration : IEntityTypeConfiguration<Director>
    {
        public void Configure(EntityTypeBuilder<Director> builder)
        {
            // Define primary key
            builder.HasKey(d => d.DirectorId);

            // Configure properties
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(255);

            // Configure relationships
            builder.HasMany(d => d.Films)
                .WithOne(f => f.Director)
                .HasForeignKey(f => f.DirectorId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
