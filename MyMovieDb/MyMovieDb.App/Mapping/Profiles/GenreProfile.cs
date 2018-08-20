using AutoMapper;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Moderator;
using MyMovieDb.Models;

namespace MyMovieDb.App.Mapping.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreViewModel>();

            CreateMap<Genre, GenreBindingModel>();
            CreateMap<GenreBindingModel, Genre>();
        }
    }
}
