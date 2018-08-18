using System;
using System.Collections.Generic;
using System.Text;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Moderator;

namespace MyMovieDb.Services.Moderator.Interfaces
{
    public interface IModeratorGenreService
    {
        ICollection<GenreViewModel> GetAllGenres();

        GenreBindingModel Add(GenreBindingModel model);

        GenreBindingModel GetGenreById(int id);

        GenreBindingModel EditGenre(GenreBindingModel model);

        GenreBindingModel DeleteGenre(int id);
    }
}
