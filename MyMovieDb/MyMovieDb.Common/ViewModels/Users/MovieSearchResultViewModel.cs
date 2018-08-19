using MyMovieDb.Common.BindingModels;

namespace MyMovieDb.Common.ViewModels.Users
{
    public class MovieSearchResultViewModel : BaseModel
    {
        public string Title { get; set; }

        public string Note { get; set; }

        public string CoverImageUrl { get; set; }
    }
}
