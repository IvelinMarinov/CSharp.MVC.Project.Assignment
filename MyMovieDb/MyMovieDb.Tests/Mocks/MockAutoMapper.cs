using AutoMapper;
using MyMovieDb.App.Mapping.Profiles;

namespace MyMovieDb.Tests.Mocks
{
    public static class MockAutoMapper
    {
        static MockAutoMapper()
        {
            Mapper.Initialize(config => config.AddProfile(new GenreProfile()));
        }

        public static IMapper GetMapper()
        {
            return Mapper.Instance;
        }
    }
}
