using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyMovieDb.Common.Enums;
using MyMovieDb.Common.ViewModels.Moderator;

namespace MyMovieDb.Common.BindingModels.Moderator
{
    public class MovieBindingModel : BaseBindingModel
    {
        public MovieBindingModel()
        {
            this.AllGenres = new HashSet<GenreViewModel>();
            this.AllPeople = new HashSet<PersonShortViewModel>();

            this.SelectedGenresIds = new List<int>();
            this.SelectedActorIds = new List<int>();
            this.SelectedDirectorIds = new List<int>();
            this.SelectedProducerIds = new List<int>();
            this.SelectedScriptWriterIds = new List<int>();
        }

        [StringLength(128)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Plot")]
        [StringLength(1024)]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Duration in minutes")]
        [Range(0, 500)]
        public int DurationInMinutes { get; set; }

        [Display(Name = "Cover Image URL")]
        [DataType(DataType.ImageUrl)]
        public string CoverImageUrl { get; set; }

        [Display(Name = "Trailer Video URL")]
        [Url]
        public string TrailerVideoUrl { get; set; }

        [Display(Name = "Premiere Date")]
        [DataType(DataType.Date)]
        public DateTime PremiereDate { get; set; }

        [Display(Name = "DVD Release Date")]
        [DataType(DataType.Date)]
        public DateTime DvdReleaseDate { get; set; }

        [Required]
        public MovieStatus Status { get; set; }

        [Display(Name = "Genres")]
        public ICollection<int> SelectedGenresIds { get; set; }

        [Display(Name = "Actors")]
        public ICollection<int> SelectedActorIds { get; set; }

        [Display(Name = "Directed By")]
        public ICollection<int> SelectedDirectorIds { get; set; }

        [Display(Name = "Produced By")]
        public ICollection<int> SelectedProducerIds { get; set; }

        [Display(Name = "Written By")]
        public ICollection<int> SelectedScriptWriterIds { get; set; }

        public ICollection<PersonShortViewModel> AllPeople { get; set; }

        public ICollection<GenreViewModel> AllGenres { get; set; }
    }
}
