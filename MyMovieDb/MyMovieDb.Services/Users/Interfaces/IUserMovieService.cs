using MyMovieDb.Common.ViewModels.Users;

namespace MyMovieDb.Services.Users.Interfaces
{
    public interface IUserMovieService
    {
        MovieDetailsViewModel GetMovieById(int id);
    }
}
