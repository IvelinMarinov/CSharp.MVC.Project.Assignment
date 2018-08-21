using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyMovieDb.App.Models;
using MyMovieDb.Common.ViewModels.Users;
using MyMovieDb.Services.Users.Interfaces;

namespace MyMovieDb.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserArticleService articleService;
        private readonly IUserTheaterProgramService theaterProgramService;

        public HomeController(
            IUserArticleService articleService, 
            IUserTheaterProgramService theaterProgramService)
        {
            this.articleService = articleService;
            this.theaterProgramService = theaterProgramService;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                Articles = this.articleService.GetLastTenArticles(),
                NowPlaying = this.theaterProgramService.GetMoviewPlayingNow()
            };

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
