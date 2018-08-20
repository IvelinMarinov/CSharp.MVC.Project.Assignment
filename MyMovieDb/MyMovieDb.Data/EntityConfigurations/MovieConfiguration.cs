using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMovieDb.Models;

namespace MyMovieDb.Data.EntityConfigurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasMany(m => m.Genres)
                .WithOne(g => g.Movie)
                .HasForeignKey(g => g.MovieId);

            builder.HasMany(m => m.Actors)
                .WithOne(a => a.Movie)
                .HasForeignKey(a => a.MovieId);

            builder.HasMany(m => m.Directors)
                .WithOne(a => a.Movie)
                .HasForeignKey(a => a.MovieId);

            builder.HasMany(m => m.Producers)
                .WithOne(a => a.Movie)
                .HasForeignKey(a => a.MovieId);

            builder.HasMany(m => m.ScriptWriters)
                .WithOne(a => a.Movie)
                .HasForeignKey(a => a.MovieId);

            builder.HasMany(m => m.InTheater)
                .WithOne(mt => mt.Movie)
                .HasForeignKey(mt => mt.MovieId);
        }
    }
}
