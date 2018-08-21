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
    public class TheaterProgramController : BaseController
    {
        private readonly IModeratorTheaterProgramService programService;
        private readonly IModeratorMovieService movieService;

        public TheaterProgramController(
            IModeratorTheaterProgramService programService, 
            IModeratorMovieService movieService)
        {
            this.programService = programService;
            this.movieService = movieService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var programs = this.programService.GetAll()
                .OrderByDescending(p => p.DateFrom)
                .ToList();

            return this.View(programs);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new TheaterProgramBindingModel
            {
                AllMovies = this.movieService.GetAllMovies()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(TheaterProgramBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }
            
            var result = this.programService.Add(model);
            if (result.HasError)
            {
                SetMessage(MessageType.Danger, result.Message);
                return this.View(model);
            }

            SetMessage(MessageType.Success, $"Program added successfully");
            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = this.programService.GetById(id);
            model.AllMovies = this.movieService.GetAllMovies();

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(TheaterProgramBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = this.programService.Edit(model);
            if (result.HasError)
            {
                SetMessage(MessageType.Danger, result.Message);
                return this.View(result);
            }

            SetMessage(MessageType.Success, $"Program edited successfully");
            return this.RedirectToAction("All");
        }
    }
}