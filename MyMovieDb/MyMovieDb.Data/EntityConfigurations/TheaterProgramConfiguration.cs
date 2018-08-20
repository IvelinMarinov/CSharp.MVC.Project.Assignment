using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMovieDb.Models;

namespace MyMovieDb.Data.EntityConfigurations
{
    public class TheaterProgramConfiguration : IEntityTypeConfiguration<TheaterProgram>
    {
        public void Configure(EntityTypeBuilder<TheaterProgram> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(mt => mt.Movies)
                .WithOne(mt => mt.TheaterProgram)
                .HasForeignKey(mt => mt.TheaterProgramId);
        }
    }
}
