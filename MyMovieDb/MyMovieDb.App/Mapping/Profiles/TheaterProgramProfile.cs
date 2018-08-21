using System.Linq;
using AutoMapper;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Moderator;
using MyMovieDb.Common.ViewModels.Users;
using MyMovieDb.Models;

namespace MyMovieDb.App.Mapping.Profiles
{
    public class TheaterProgramProfile : Profile
    {
        public TheaterProgramProfile()
        {
            CreateMap<TheaterProgram, TheaterProgramShortListViewModel>();

            CreateMap<TheaterProgramBindingModel, TheaterProgram>();
            CreateMap<TheaterProgram, TheaterProgramBindingModel>()
                .ForMember(dest => dest.SelectedMoviesIds, opts => opts.MapFrom(src => src.Movies.Select(mt => mt.MovieId)));

            CreateMap<TheaterProgram, TheaterProgramViewModel>()
                .ForMember(dest => dest.Movies, opts => opts.MapFrom(src => src.Movies.Select(mp =>
                    new MovieShortListModel
                    {
                        Id = mp.MovieId,
                        Title = mp.Movie.Title
                    })));
        }
    }
}
