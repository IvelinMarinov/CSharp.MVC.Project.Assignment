using MyMovieDb.Common.ViewModels.Users;

namespace MyMovieDb.Services.Users.Interfaces
{
    public interface IUserPeopleService
    {
        PersonDetailsViewModel GetPersonById(int id);
    }
}
