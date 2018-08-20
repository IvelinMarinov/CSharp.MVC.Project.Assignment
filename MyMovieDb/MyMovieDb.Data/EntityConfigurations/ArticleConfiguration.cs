using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMovieDb.Models;

namespace MyMovieDb.Data.EntityConfigurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>

    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(a => a.Author)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.AuthorId);
        }
    }
}