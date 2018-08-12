using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMovieDb.Models;

namespace MyMovieDb.Data.EntityConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasKey(g => g.Id);

            builder.HasMany(g => g.Movies)
                .WithOne(m => m.Genre)
                .HasForeignKey(m => m.GenreId);
        }
    }
}
