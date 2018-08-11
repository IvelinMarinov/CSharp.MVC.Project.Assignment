using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMovieDb.Models;

namespace MyMovieDb.Data.EntityConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.MoviesActedIn)
                .WithOne(m => m.Person)
                .HasForeignKey(m => m.PersonId);

            builder.HasMany(p => p.MoviesDirected)
                .WithOne(m => m.Person)
                .HasForeignKey(m => m.PersonId);

            builder.HasMany(p => p.MoviesProduced)
                .WithOne(m => m.Person)
                .HasForeignKey(m => m.PersonId);

            builder.HasMany(p => p.MoviesWroteScriptFor)
                .WithOne(m => m.Person)
                .HasForeignKey(m => m.PersonId);
        }
    }
}
