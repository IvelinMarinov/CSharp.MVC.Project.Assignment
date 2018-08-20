using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMovieDb.Data.EntityConfigurations;
using MyMovieDb.Models;

namespace MyMovieDb.Data
{
    public class MyMovieDbContext : IdentityDbContext<User>
    {
        public MyMovieDbContext(DbContextOptions<MyMovieDbContext> options)
            :base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActors> MovieActors { get; set; }
        public DbSet<MovieDirectors> MovieDirectors { get; set; }
        public DbSet<MovieGenres> MovieGenres { get; set; }
        public DbSet<MovieProducers> MovieProducers { get; set; }
        public DbSet<MovieScriptWriters> MovieScriptWriters { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MovieConfiguration());
            builder.ApplyConfiguration(new PersonConfiguration());
            builder.ApplyConfiguration(new GenreConfiguration());
            builder.ApplyConfiguration(new MovieGenresConfiguration());
            builder.ApplyConfiguration(new ArticleConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
