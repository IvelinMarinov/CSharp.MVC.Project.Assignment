using System;
using MyMovieDb.Common.BindingModels;

namespace MyMovieDb.Common.ViewModels.Moderator
{
    public class TheaterProgramShortListViewModel : BaseModel
    {
        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
