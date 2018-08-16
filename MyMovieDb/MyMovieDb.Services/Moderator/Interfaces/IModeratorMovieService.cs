using System.Collections.Generic;
using MyMovieDb.Common.ViewModels.Moderator;

namespace MyMovieDb.Services.Moderator.Interfaces
{
    public interface IModeratorMovieService
    {
        ICollection<MovieShortListModel> GetAllMovies();
    }
}
