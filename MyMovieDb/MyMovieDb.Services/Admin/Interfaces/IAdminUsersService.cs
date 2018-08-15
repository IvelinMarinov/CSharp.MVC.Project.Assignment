using System.Collections.Generic;
using System.Threading.Tasks;
using MyMovieDb.Common.ViewModels.Admin;

namespace MyMovieDb.Services.Admin.Interfaces
{
    public interface IAdminUsersService
    {
        Task<ICollection<ManageUserViewModel>> GetAllUsersAsync();

        Task<bool> GiveModeratorRightsToUserAsync(string usedId);

        Task<bool> RemoveModeratorRightsFromUserAsync(string usedId);

    }
}
