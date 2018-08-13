
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovieDb.Services.Admin.Interfaces;

namespace MyMovieDb.App.Areas.Admin.Controllers
{
    [Area(StringConstants.Admin)]
    [Authorize(Roles = StringConstants.Admin)]
    public class HomeController : Controller
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
        public IActionResult ManageUsers()
        {
            var users = this.userService.GetAllUsers();

            return this.View(users);
        }
    }
}