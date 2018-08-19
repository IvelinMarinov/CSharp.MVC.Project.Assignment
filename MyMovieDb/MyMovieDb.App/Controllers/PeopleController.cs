using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovieDb.Services.Users.Interfaces;

namespace MyMovieDb.App.Controllers
{
    [AllowAnonymous]
    public class PeopleController : BaseController
    {
        private readonly IUserPeopleService peopleService;

        public PeopleController(IUserPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        public IActionResult Details(int id)
        {
            var person = this.peopleService.GetPersonById(id);

            return View(person);
        }
    }
}