
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyMovieDb.App.Controllers;
using MyMovieDb.App.Helpers.Messages;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Models;
using MyMovieDb.Services.Moderator.Interfaces;

namespace MyMovieDb.App.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    [Authorize(Roles = "Admin, Moderator")]
    public class ArticlesController : BaseController
    {
        private readonly IModeratorArticleService articleService;
        private readonly UserManager<User> userManager; 

        public ArticlesController(IModeratorArticleService articleService, UserManager<User> userManager)
        {
            this.articleService = articleService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult All()
        {
            var articles = this.articleService.GetAllArticles()
                .OrderByDescending(a => a.CreatedDate)
                .ToList();

            return this.View(articles);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ArticleBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            model.AuthorId = this.userManager.GetUserId(this.User);
            model.CreatedDate = DateTime.Now;

            var result = this.articleService.AddArticle(model);
            if (result.HasError)
            {
                SetMessage(MessageType.Danger, result.Message);
                return this.View(model);
            }

            SetMessage(MessageType.Success, $"Article added successfully");
            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = this.articleService.GetArticleById(id);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(ArticleBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = this.articleService.EditArticle(model);
            if (result.HasError)
            {
                SetMessage(MessageType.Danger, result.Message);
                return this.View(result);
            }

            SetMessage(MessageType.Success, $"Article edited successfully");
            return this.RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = this.articleService.DeleteArticle(id);
            if (result.HasError)
            {
                SetMessage(MessageType.Danger, result.Message);
            }

            SetMessage(MessageType.Success, $"Article deleted successfully");
            return this.RedirectToAction("All");
        }
    }
}