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
        private readonly IModeratorMovieService moderatorMovieService;
        private readonly IModeratorGenreService genreService;
        private readonly IModeratorPersonService personService;

        public MoviesController(IModeratorMovieService moderatorMovieService)
        {
            this.moderatorMovieService = moderatorMovieService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var movies = this.moderatorMovieService.GetAllMovies();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var allGenres = this.genreService.GetAllGenres();
            var allPeople = this.personService.GetAllPeople();

            var model = new MovieBindingModel
            {
                AllGenres = allGenres,
                AllPeople = allPeople
            };

            return View();
        }

        [HttpPost]
        public IActionResult Add(MovieBindingModel model)
        {
            return null;
        }
    }
}