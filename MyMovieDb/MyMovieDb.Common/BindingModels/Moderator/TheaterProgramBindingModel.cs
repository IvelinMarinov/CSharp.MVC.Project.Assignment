using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyMovieDb.Common.ViewModels.Moderator;

namespace MyMovieDb.Common.BindingModels.Moderator
{
    public class TheaterProgramBindingModel : BaseModel
    {
        public TheaterProgramBindingModel()
        {
            this.SelectedMoviesIds = new List<int>();
            this.AllMovies = new List<MovieShortListModel>();
        }

        [Display(Name = "Date From")]
        [DataType(DataType.Date)]
        public DateTime DateFrom { get; set; }

        [Display(Name = "Date To")]
        [DataType(DataType.Date)]
        public DateTime DateTo { get; set; }

        [Display(Name = "Movies")]
        public ICollection<int> SelectedMoviesIds { get; set; }
        
        public ICollection<MovieShortListModel> AllMovies { get; set; }

    }
}
