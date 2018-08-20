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

            CreateMap<TheaterProgram, TheaterProgramBindingModel>();
            CreateMap<TheaterProgramBindingModel, TheaterProgram>();
        }
    }
}
