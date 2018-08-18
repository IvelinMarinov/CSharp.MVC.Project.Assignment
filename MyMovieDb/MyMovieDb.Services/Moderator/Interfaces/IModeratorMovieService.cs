using System.Collections.Generic;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Moderator;

namespace MyMovieDb.Services.Moderator.Interfaces
{
    public interface IModeratorMovieService
    {
        ICollection<MovieShortListModel> GetAllMovies();

        MovieBindingModel AddMovie(MovieBindingModel model);

        MovieBindingModel GetMovieById(int id);

        MovieBindingModel EditMovie(MovieBindingModel model);

        MovieBindingModel DeleteMovie(int id);
    }
}
