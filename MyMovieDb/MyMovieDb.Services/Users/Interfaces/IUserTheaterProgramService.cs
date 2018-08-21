using MyMovieDb.Common.ViewModels.Users;

namespace MyMovieDb.Services.Users.Interfaces
{
    public interface IUserTheaterProgramService
    {
        TheaterProgramViewModel GetMoviewPlayingNow();
    }
}
