using System.Linq;
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
        private readonly IModeratorMovieService movieService;
        private readonly IModeratorGenreService genreService;
        private readonly IModeratorPersonService personService;

        public MoviesController(
            IModeratorMovieService movieService,
            IModeratorGenreService genreService,
            IModeratorPersonService personService)
        {
            this.movieService = movieService;
            this.genreService = genreService;
            this.personService = personService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var movies = this.movieService.GetAllMovies()
                .OrderBy(m => m.Title)
                .ToList();

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

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(MovieBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = this.movieService.Add(model);

            return null;
        }
    }
}