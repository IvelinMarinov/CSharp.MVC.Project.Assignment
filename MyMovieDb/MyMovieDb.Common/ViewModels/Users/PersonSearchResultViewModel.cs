using MyMovieDb.Common.BindingModels;

namespace MyMovieDb.Common.ViewModels.Users
{
    public class PersonSearchResultViewModel : BaseModel
    {
        public string Name { get; set; }

        public string Note { get; set; }

        public string PhotoImageUrl { get; set; }
    }
}
