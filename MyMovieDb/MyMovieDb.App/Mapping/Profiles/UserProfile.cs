using AutoMapper;
using MyMovieDb.Common.ViewModels.Admin;
using MyMovieDb.Models;

namespace MyMovieDb.App.Mapping.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, ManageUserViewModel>()
                .AfterMap((s, d) => d.FullName = $"{s.FirstName} {s.LastName}");
        }
    }
}
