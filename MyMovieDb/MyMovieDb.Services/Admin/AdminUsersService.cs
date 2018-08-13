using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMovieDb.Common.ViewModels.Admin;
using MyMovieDb.Data;
using MyMovieDb.Services.Admin.Interfaces;

namespace MyMovieDb.Services.Admin
{
    public class AdminUsersService : BaseService, IAdminUsersService
    {
        public AdminUsersService(MyMovieDbContext dbContext, IMapper mapper)
            :base(dbContext, mapper)
        {
        }

        public ICollection<ManageUserViewModel> GetAllUsers()
        {
            var users = DbContext.Users
                .ToList();

            var userViewModels = Mapper.Map<List<ManageUserViewModel>>(users);

            return userViewModels;
        }
    }
}
