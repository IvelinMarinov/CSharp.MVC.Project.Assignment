using System.Collections.Generic;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Moderator;

namespace MyMovieDb.Services.Moderator.Interfaces
{
    public interface IModeratorPersonService
    {
        ICollection<PersonShortViewModel> GetAllPeople();

        PersonBindingModel AddPerson(PersonBindingModel model);

        PersonBindingModel GetPersonById(int id);

        PersonBindingModel EditPerson(PersonBindingModel model);

        PersonBindingModel DeletePerson(int id);
    }
}
