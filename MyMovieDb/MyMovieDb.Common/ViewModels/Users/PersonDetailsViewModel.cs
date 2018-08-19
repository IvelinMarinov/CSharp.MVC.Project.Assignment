using System;
using System.Collections.Generic;
using MyMovieDb.Common.BindingModels;
using MyMovieDb.Common.Enums;
using MyMovieDb.Common.ViewModels.Moderator;

namespace MyMovieDb.Common.ViewModels.Users
{
    public class PersonDetailsViewModel : BaseModel
    {
        public PersonDetailsViewModel()
        {
            this.MoviesActedIn = new HashSet<MoviePersonFilmographyViewModel>();
            this.MoviesDirected = new HashSet<MoviePersonFilmographyViewModel>();
            this.MoviesProduced = new HashSet<MoviePersonFilmographyViewModel>();
            this.MoviesWroteScriptFor = new HashSet<MoviePersonFilmographyViewModel>();
        }

        public string Biography { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Alias { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PlaceOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string PhotoImageUrl { get; set; }

        public ICollection<MoviePersonFilmographyViewModel> MoviesActedIn { get; set; }

        public ICollection<MoviePersonFilmographyViewModel> MoviesDirected { get; set; }

        public ICollection<MoviePersonFilmographyViewModel> MoviesProduced { get; set; }

        public ICollection<MoviePersonFilmographyViewModel> MoviesWroteScriptFor { get; set; }
    }
}
