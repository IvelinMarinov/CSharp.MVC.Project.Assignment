using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMovieDb.Models;

namespace MyMovieDb.Data.EntityConfigurations
{
    public class MovieGenresConfiguration : IEntityTypeConfiguration<MovieGenres>
    {
        public void Configure(EntityTypeBuilder<MovieGenres> builder)
        {
            builder.HasKey(mg => new {mg.MovieId, mg.GenreId});
        }
    }
}
