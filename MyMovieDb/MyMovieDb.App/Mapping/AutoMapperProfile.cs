using AutoMapper;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Admin;
using MyMovieDb.Common.ViewModels.Moderator;
using MyMovieDb.Models;

namespace MyMovieDb.App.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, ManageUserViewModel>()
                .AfterMap((s,d) => d.FullName = $"{s.FirstName} {s.LastName}");

            CreateMap<Person, PersonBindingModel>();
            CreateMap<PersonBindingModel, Person>();

            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreBindingModel>();
            CreateMap<GenreBindingModel, Genre>();

            CreateMap<MovieBindingModel, Movie>()
                .ForMember(src => src.Genres, opts => opts.Ignore())
                .ForMember(src => src.Actors, opts => opts.Ignore())
                .ForMember(src => src.Directors, opts => opts.Ignore())
                .ForMember(src => src.Producers, opts => opts.Ignore())
                .ForMember(src => src.ScriptWriters, opts => opts.Ignore());

        }
    }
}
