using MyMovieDb.Common.BindingModels;

namespace MyMovieDb.Common.ViewModels.Users
{
    public class MoviePersonFilmographyViewModel : BaseModel
    {
        public string Title { get; set; }

        public string Status { get; set; }

        public string Year { get; set; }
    }
}
