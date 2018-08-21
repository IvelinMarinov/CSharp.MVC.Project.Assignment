using System.Linq;
using AutoMapper;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Moderator;
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
        }
    }
}
