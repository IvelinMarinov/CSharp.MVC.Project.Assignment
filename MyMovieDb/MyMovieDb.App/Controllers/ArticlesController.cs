using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovieDb.App.Helpers.Messages;
using MyMovieDb.Services.Users.Interfaces;

namespace MyMovieDb.App.Controllers
{
    [AllowAnonymous]
    public class ArticlesController : BaseController
    {
        private readonly IUserArticleService articleService;

        public ArticlesController(IUserArticleService articleService)
        {
            this.articleService = articleService;
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null || id == default(int))
            {
                return this.RedirectToAction("Index", "Home");
            }

            var article = this.articleService.GetArticleById(id.Value);
            if (article.HasError)
            {
                SetMessage(MessageType.Danger, article.Message);
                return this.RedirectToAction("Index", "Home");
            }

            return this.View(article);
        }
    }
}
