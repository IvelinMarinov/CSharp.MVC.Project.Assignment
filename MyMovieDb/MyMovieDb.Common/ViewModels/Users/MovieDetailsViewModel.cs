using System;
using System.Collections.Generic;
using MyMovieDb.Common.BindingModels;
using MyMovieDb.Common.Enums;
using MyMovieDb.Common.ViewModels.Moderator;

namespace MyMovieDb.Common.ViewModels.Users
{
    public class MovieDetailsViewModel : BaseModel
    {
        public MovieDetailsViewModel()
        {
            this.Genres = new HashSet<string>();
            this.Actors = new HashSet<PersonMovieCastViewModel>();
            this.Directors = new HashSet<PersonMovieCastViewModel>();
            this.Producers = new HashSet<PersonMovieCastViewModel>();
            this.ScriptWriters = new HashSet<PersonMovieCastViewModel>();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public int DurationInMinutes { get; set; }

        public string CoverImageUrl { get; set; }

        public string TrailerYoutubeId { get; set; }

        public DateTime PremiereDate { get; set; }

        public DateTime DvdReleaseDate { get; set; }

        public MovieStatus Status { get; set; }

        public ICollection<string> Genres { get; set; }

        public ICollection<PersonMovieCastViewModel> Actors { get; set; }

        public ICollection<PersonMovieCastViewModel> Directors { get; set; }

        public ICollection<PersonMovieCastViewModel> Producers { get; set; }

        public ICollection<PersonMovieCastViewModel> ScriptWriters { get; set; }
    }
}
