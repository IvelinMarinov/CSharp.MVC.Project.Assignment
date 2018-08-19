using MyMovieDb.Common.BindingModels;

namespace MyMovieDb.Common.ViewModels.Users
{
    public class PersonMovieCastViewModel : BaseModel
    {
        public string Name { get; set; }

        public string PhotoImageUrl { get; set; }
    }
}
