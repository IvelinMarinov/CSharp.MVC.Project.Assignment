using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Services.Users.Interfaces;

namespace MyMovieDb.App.Controllers
{
    public class MoviesController : BaseController
    {
        private readonly IUserMovieService movieService;

        public MoviesController(IUserMovieService movieService)
        {
            this.movieService = movieService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var movie = this.movieService.GetMovieById(id);
            return View(movie);
        }
    }
}