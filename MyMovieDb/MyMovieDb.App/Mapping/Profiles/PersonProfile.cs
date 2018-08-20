using System.Linq;
using AutoMapper;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Users;
using MyMovieDb.Models;

namespace MyMovieDb.App.Mapping.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonBindingModel>();
            CreateMap<PersonBindingModel, Person>();

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
        }
    }
}
