using System.Collections.Generic;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Moderator;

namespace MyMovieDb.Services.Moderator.Interfaces
{
    public interface IModeratorTheaterProgramService
    {
        ICollection<TheaterProgramShortListViewModel> GetAll();

        TheaterProgramBindingModel Add(TheaterProgramBindingModel model);

        TheaterProgramBindingModel GetById(int id);

        TheaterProgramBindingModel Edit(TheaterProgramBindingModel model);
    }
}
