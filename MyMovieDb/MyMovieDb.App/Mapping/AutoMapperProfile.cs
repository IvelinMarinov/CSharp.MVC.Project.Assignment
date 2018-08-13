using AutoMapper;
using MyMovieDb.Common.ViewModels.Admin;
using MyMovieDb.Models;

namespace MyMovieDb.App.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, ManageUserViewModel>();
        }
    }
}
