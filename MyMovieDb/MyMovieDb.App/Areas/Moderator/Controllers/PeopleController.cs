using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMovieDb.App.Controllers;
using MyMovieDb.App.Helpers.Messages;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Services.Moderator.Interfaces;

namespace MyMovieDb.App.Areas.Moderator.Controllers
{
    [Area("Moderator")]
    [Authorize(Roles = "Admin, Moderator")]
    public class PeopleController : BaseModeratorController
    {
        private IModeratorPersonService personService;

        public PeopleController(
            IModeratorPersonService personService, 
            IHttpContextAccessor contextAccessor)
            : base(contextAccessor)
        {
            this.personService = personService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var people = this.personService.GetAllPeople()
                .OrderBy(p => p.FullName)
                .ToList();

            return View(people);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(PersonBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = this.personService.AddPerson(model);
            LogResult(result);

            if (result.HasError)
            {
                SetMessage(MessageType.Danger, result.Message);
                return this.View(model);
            }

            SetMessage(MessageType.Success, $"{model.FirstName} {model.LastName} added successfully");
            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = this.personService.GetPersonById(id);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Edit(PersonBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = this.personService.EditPerson(model);
            LogResult(result);

            if (result.HasError)
            {
                SetMessage(MessageType.Danger, result.Message);
                return this.View(result);
            }

            SetMessage(MessageType.Success, $"{model.FirstName} {model.LastName} edited successfully");
            return this.RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = this.personService.DeletePerson(id);
            LogResult(result);

            if (result.HasError)
            {
                SetMessage(MessageType.Success, "Internal Server Error");
                return this.RedirectToAction("All");
            }

            SetMessage(MessageType.Success, $"{result.FirstName} {result.LastName} deleted successfully");
            return this.RedirectToAction("All");
        }
    }
}