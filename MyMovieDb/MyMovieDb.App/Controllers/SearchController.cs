using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovieDb.Services.Users.Interfaces;

namespace MyMovieDb.App.Controllers
{
    [AllowAnonymous]
    public class SearchController : BaseController
    {
        private readonly IUserSearchService searchService;

        public SearchController(IUserSearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpPost]
        public IActionResult Results(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return this.RedirectToAction("Index", "Home");
            }

            var results = this.searchService.SearchByNameOrTitle(searchString);

            return this.View(results);
        }
    }
}