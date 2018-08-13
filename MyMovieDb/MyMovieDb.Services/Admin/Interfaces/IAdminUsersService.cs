using System.Collections.Generic;
using MyMovieDb.Common.ViewModels.Admin;

namespace MyMovieDb.Services.Admin.Interfaces
{
    public interface IAdminUsersService
    {
        ICollection<ManageUserViewModel> GetAllUsers();
    }
}
