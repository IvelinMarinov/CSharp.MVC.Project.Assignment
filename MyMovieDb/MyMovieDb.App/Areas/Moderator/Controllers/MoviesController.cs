using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovieDb.App.Controllers;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Services.Moderator.Interfaces;

namespace MyMovieDb.App.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    [Authorize(Roles = "Admin, Moderator")]
    public class MoviesController : BaseController
    {
        private readonly IModeratorMovieService _moderatorMovieService;

        public MoviesController(IModeratorMovieService moderatorMovieService)
        {
            this._moderatorMovieService = moderatorMovieService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var movies = this._moderatorMovieService.GetAllMovies();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(MovieBindingModel model)
        {
            return null;
        }
    }
}