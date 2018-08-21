using System.Collections.Generic;
using MyMovieDb.Common.BindingModels;

namespace MyMovieDb.Common.ViewModels.Users
{
    public class HomePageViewModel : BaseModel
    {
        public HomePageViewModel()
        {
            this.Articles = new HashSet<ArticleViewModel>();
        }

        public ICollection<ArticleViewModel> Articles { get; set; }

        public TheaterProgramViewModel NowPlaying { get; set; }
    }
}
