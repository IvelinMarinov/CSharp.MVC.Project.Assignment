using AutoMapper;
using MyMovieDb.App.Mapping.Profiles;

namespace MyMovieDb.App.Mapping
{
    public class AutoMapperConfiguration : Profile
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new UserProfile());
                cfg.AddProfile(new MovieProfile());
                cfg.AddProfile(new PersonProfile());
                cfg.AddProfile(new GenreProfile());
                cfg.AddProfile(new ArticleProfile());
                cfg.AddProfile(new TheaterProgramProfile());
                cfg.AddProfile(new MovieVotesProfile());
            });
        }
    }
}
