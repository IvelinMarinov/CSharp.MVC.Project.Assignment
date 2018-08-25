using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovieDb.App.Helpers.Messages;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Users;
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
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return this.RedirectToAction("Index", "Home");
            }

            SetMessage(MessageType.Info, "Testing");

            var movie = this.movieService.GetMovieById(id.Value);
            return View(movie);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Rate(MovieVoteBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                SetMessage(MessageType.Info,  "An error occured");
                return this.RedirectToAction("Details", new {id = model.MovieId});
            }

            var result = this.movieService.AddEditMovieVote(model);
            SetMessage(MessageType.Info, $"You rated the movie with {model.Vote}");

            return this.RedirectToAction("Details", new { id = model.MovieId });
        }

        [HttpGet]
        [Authorize]
        public ActionResult CheckIfUserAlreadyVotedForMovie(int movieId, string userId)
        {
            var result = this.movieService.GetRatingForExistingVote(movieId, userId);

            return Json(result);
        }
    }
}