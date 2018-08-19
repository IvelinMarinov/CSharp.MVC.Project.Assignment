using System.Collections.Generic;

namespace MyMovieDb.Common.ViewModels.Users
{
    public class SearchResultsViewModel
    {
        public SearchResultsViewModel()
        {
            this.MoviesFound = new List<MovieSearchResultViewModel>();
            this.PeopleFound = new List<PersonSearchResultViewModel>();
        }

        public string SearchString { get; set; }

        public ICollection<MovieSearchResultViewModel> MoviesFound { get; set; }

        public ICollection<PersonSearchResultViewModel> PeopleFound { get; set; }
    }
}
