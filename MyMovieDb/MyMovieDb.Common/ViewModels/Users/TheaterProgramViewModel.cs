using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyMovieDb.Common.BindingModels;
using MyMovieDb.Common.ViewModels.Moderator;

namespace MyMovieDb.Common.ViewModels.Users
{
    public class TheaterProgramViewModel : BaseModel
    {
        public TheaterProgramViewModel()
        {
            this.Movies = new HashSet<MovieShortListModel>();
        }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public ICollection<MovieShortListModel> Movies { get; set; }
    }
}
