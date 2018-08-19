using System.Linq;
using AutoMapper;
using MyMovieDb.App.Common.Constants;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Admin;
using MyMovieDb.Common.ViewModels.Moderator;
using MyMovieDb.Common.ViewModels.Users;
using MyMovieDb.Models;

namespace MyMovieDb.App.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, ManageUserViewModel>()
                .AfterMap((s, d) => d.FullName = $"{s.FirstName} {s.LastName}");

            CreateMap<Person, PersonBindingModel>();
            CreateMap<PersonBindingModel, Person>();

            CreateMap<Genre, GenreViewModel>();
            CreateMap<Genre, GenreBindingModel>();
            CreateMap<GenreBindingModel, Genre>();

            CreateMap<MovieBindingModel, Movie>()
                .ForMember(dest => dest.Genres, opts => opts.Ignore())
                .ForMember(dest => dest.Actors, opts => opts.Ignore())
                .ForMember(dest => dest.Directors, opts => opts.Ignore())
                .ForMember(dest => dest.Producers, opts => opts.Ignore())
                .ForMember(dest => dest.ScriptWriters, opts => opts.Ignore());

            CreateMap<Movie, MovieBindingModel>()
                .ForMember(dest => dest.SelectedGenresIds,opts => opts.MapFrom(src => src.Genres.Select(mg => mg.GenreId)))
                .ForMember(dest => dest.SelectedActorIds, opts => opts.MapFrom(src => src.Actors.Select(mg => mg.PersonId)))
                .ForMember(dest => dest.SelectedDirectorIds, opts => opts.MapFrom(src => src.Directors.Select(mg => mg.PersonId)))
                .ForMember(dest => dest.SelectedProducerIds, opts => opts.MapFrom(src => src.Producers.Select(mg => mg.PersonId)))
                .ForMember(dest => dest.SelectedScriptWriterIds, opts => opts.MapFrom(src => src.ScriptWriters.Select(mg => mg.PersonId)));

            CreateMap<Movie, MovieSearchResultViewModel>()
                .ForMember(dest => dest.Title, opts => opts.MapFrom(m => $"{m.Title} ({m.PremiereDate.Year})"))
                .AfterMap((s, d) => d.Note = string.Join(", ", s.Genres.Select(mg => mg.Genre.Description).OrderBy(g => g)));

            CreateMap<Person, PersonSearchResultViewModel>()
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
