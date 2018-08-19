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

            CreateMap<Person, PersonDetailsViewModel>()
                .ForMember(dest => dest.MoviesActedIn,
                    opts => opts.MapFrom(src => src.MoviesActedIn.Select(ma => new MoviePersonFilmographyViewModel
                    {
                        Id = ma.Movie.Id,
                        Title = ma.Movie.Title,
                        Year = ma.Movie.PremiereDate.Year.ToString(),
                        Status = ma.Movie.Status.ToString()
                    })))
                .ForMember(dest => dest.MoviesDirected,
                    opts => opts.MapFrom(src => src.MoviesDirected.Select(ma => new MoviePersonFilmographyViewModel
                    {
                        Id = ma.Movie.Id,
                        Title = ma.Movie.Title,
                        Year = ma.Movie.PremiereDate.Year.ToString(),
                        Status = ma.Movie.Status.ToString()
                    })))
                .ForMember(dest => dest.MoviesProduced,
                    opts => opts.MapFrom(src => src.MoviesProduced.Select(ma => new MoviePersonFilmographyViewModel
                    {
                        Id = ma.Movie.Id,
                        Title = ma.Movie.Title,
                        Year = ma.Movie.PremiereDate.Year.ToString(),
                        Status = ma.Movie.Status.ToString()
                    })))
                .ForMember(dest => dest.MoviesWroteScriptFor,
                    opts => opts.MapFrom(src => src.MoviesWroteScriptFor.Select(ma => new MoviePersonFilmographyViewModel
                    {
                        Id = ma.Movie.Id,
                        Title = ma.Movie.Title,
                        Year = ma.Movie.PremiereDate.Year.ToString(),
                        Status = ma.Movie.Status.ToString()
                    })));

            CreateMap<Movie, MovieDetailsViewModel>()
                .ForMember(dest => dest.Genres,
                    opts => opts.MapFrom(src => src.Genres.Select(mg => mg.Genre.Description)))
                .ForMember(dest => dest.Actors,
                    opts => opts.MapFrom(src => src.Actors.Select(ma => new PersonMovieCastViewModel
                    {
                        Id = ma.Person.Id,
                        Name = $"{ma.Person.FirstName} {ma.Person.LastName}",
                        PhotoImageUrl = ma.Person.PhotoImageUrl
                    })))
                .ForMember(dest => dest.Directors,
                    opts => opts.MapFrom(src => src.Directors.Select(ma => new PersonMovieCastViewModel
                    {
                        Id = ma.Person.Id,
                        Name = $"{ma.Person.FirstName} {ma.Person.LastName}",
                    })))
                .ForMember(dest => dest.Producers,
                    opts => opts.MapFrom(src => src.Producers.Select(ma => new PersonMovieCastViewModel
                    {
                        Id = ma.Person.Id,
                        Name = $"{ma.Person.FirstName} {ma.Person.LastName}",
                    })))
                .ForMember(dest => dest.ScriptWriters,
                    opts => opts.MapFrom(src => src.ScriptWriters.Select(ma => new PersonMovieCastViewModel
                    {
                        Id = ma.Person.Id,
                        Name = $"{ma.Person.FirstName} {ma.Person.LastName}",
                    })));
        }
    }
}
