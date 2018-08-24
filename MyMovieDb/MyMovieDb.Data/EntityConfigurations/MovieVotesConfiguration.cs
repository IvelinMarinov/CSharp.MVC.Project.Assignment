using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMovieDb.Models;

namespace MyMovieDb.Data.EntityConfigurations
{
    public class MovieVotesConfiguration : IEntityTypeConfiguration<MovieVotes>
    {
        public void Configure(EntityTypeBuilder<MovieVotes> builder)
        {
            builder.HasKey(mv => new {mv.UserId, mv.MovieId});
        }
    }
}
