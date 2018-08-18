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
    public class GenresController : BaseController
    {
        private readonly IModeratorGenreService genreServices;

        public GenresController(IModeratorGenreService genreServices)
        {
            this.genreServices = genreServices;
        }

        [HttpGet]
        public IActionResult All()
        {
            var genres = this.genreServices.GetAllGenres()
                .OrderBy(g => g.Description)
                .ToList();
            
            return this.View(genres);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(GenreBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = this.genreServices.Add(model);
            if (result.HasError)
            {
                SetMessage(MessageType.Danger, result.Message);
                return this.View(model);
            }

            SetMessage(MessageType.Success, $"Genre {model.Description} added successfully");
            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = this.genreServices.GetGenreById(id);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(GenreBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = this.genreServices.EditGenre(model);
            if (result.HasError)
            {
                SetMessage(MessageType.Danger, result.Message);
                return this.View(result);
            }

            SetMessage(MessageType.Success, $"Genre {model.Description} edited successfully");
            return this.RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = this.genreServices.DeleteGenre(id);
            if (result.HasError)
            {
                SetMessage(MessageType.Danger, result.Message);
            }

            SetMessage(MessageType.Success, $"Genre {result.Description} deleted successfully");
            return this.RedirectToAction("All");
        }
    }
}