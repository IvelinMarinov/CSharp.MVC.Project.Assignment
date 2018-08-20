using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMovieDb.Models;

namespace MyMovieDb.Data.EntityConfigurations
{
    public class MoviesInTheaterConfiguration : IEntityTypeConfiguration<MoviesInTheater>
    {
        public void Configure(EntityTypeBuilder<MoviesInTheater> builder)
        {
            builder.HasKey(mt => mt.Id);
        }
    }
}
