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
    public class PeopleController : BaseController
    {
        private IModeratorPersonService personService;

        public PeopleController(IModeratorPersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var people = this.personService.GetAllPeople();

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
            if (result.HasError)
            {
                SetMessage(MessageType.Danger, result.Message);
                return this.View(model);
            }

            SetMessage(MessageType.Success, "Person created successfully");
            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = this.personService.GetPersonForEditing(id);

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
            if (result.HasError)
            {
                SetMessage(MessageType.Danger, result.Message);
                return this.View(result);
            }

            SetMessage(MessageType.Success, "Person edited successfully");
            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return null;
        }
    }
}