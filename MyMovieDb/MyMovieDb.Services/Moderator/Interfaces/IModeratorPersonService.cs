using System.Collections.Generic;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Moderator;

namespace MyMovieDb.Services.Moderator.Interfaces
{
    public interface IModeratorPersonService
    {
        ICollection<PersonShortListViewModel> GetAllPeople();

        PersonBindingModel AddPerson(PersonBindingModel model);

        PersonBindingModel GetPersonForEditing(int id);

        PersonBindingModel EditPerson(PersonBindingModel model);

        bool DeletePerson(int id);
    }
}
