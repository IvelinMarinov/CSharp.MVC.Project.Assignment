using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovieDb.App.Controllers;
using MyMovieDb.App.Helpers.Messages;
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

            var result = this.movieService.AddMovie(model);

            return null;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = this.movieService.GetMovieById(id);
            model.AllGenres = this.genreService.GetAllGenres();
            model.AllPeople = this.personService.GetAllPeople();

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(MovieBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = this.movieService.EditMovie(model);
            if (result.HasError)
            {
                SetMessage(MessageType.Danger, result.Message);
                return this.View(result);
            }

            SetMessage(MessageType.Success, $"{model.Title} edited successfully");
            return this.RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = this.movieService.DeleteMovie(id);

            if (result.HasError)
            {
                SetMessage(MessageType.Success, "Internal Server Error");
                return this.RedirectToAction("All");
            }

            SetMessage(MessageType.Success, $"{result.Title} deleted successfully");
            return this.RedirectToAction("All");
        }
    }
}