using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovieDb.App.Controllers;
using MyMovieDb.Common.Constants;

namespace MyMovieDb.App.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    [Authorize(Roles = "Admin, Moderator")]
    public class HomeController : BaseController
    {
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }
    }
}