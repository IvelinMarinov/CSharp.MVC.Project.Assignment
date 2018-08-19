using MyMovieDb.Common.ViewModels.Users;

namespace MyMovieDb.Services.Users.Interfaces
{
    public interface IUserSearchService
    {
        SearchResultsViewModel SearchByNameOrTitle(string searchString);
    }
}
