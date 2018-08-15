
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovieDb.App.Controllers;
using MyMovieDb.App.Helpers.Messages;
using MyMovieDb.Common.Constants;
using MyMovieDb.Services.Admin.Interfaces;

namespace MyMovieDb.App.Areas.Admin.Controllers
{
    [Area(AppRoles.Admin)]
    [Authorize(Roles = AppRoles.Admin)]
    public class HomeController : BaseController
    {
        private IAdminUsersService userService;

        public HomeController(IAdminUsersService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return this.RedirectToAction("ManageUsers");
        }

        [HttpGet]
        public async Task<IActionResult> ManageUsers()
        {
            var users = await this.userService.GetAllUsersAsync();

            return this.View(users);
        }

        [HttpGet]
        public async Task<IActionResult> GiveModeratorRightsToUser(string userId)
        {
            var isSuccessful = await this.userService.GiveModeratorRightsToUserAsync(userId);
            if (!isSuccessful)
            {
                this.SetMessage(MessageType.Danger, "Unable to give moderator rights to user.");
            }

            this.SetMessage(MessageType.Success, "Successfully given moderator rights to user.");

            return this.RedirectToAction("ManageUsers");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveModeratorRightsFromUser(string userId)
        {
            var isSuccessful = await this.userService.RemoveModeratorRightsFromUserAsync(userId);
            if (!isSuccessful)
            {
                this.SetMessage(MessageType.Danger, "Unable to remove moderator rights from user.");
            }

            this.SetMessage(MessageType.Success, "Successfully removed moderator rights from user.");
       
            return this.RedirectToAction("ManageUsers");
        }
    }
}