using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyMovieDb.Common.Enums;
using MyMovieDb.Common.ViewModels.Moderator;

namespace MyMovieDb.Common.BindingModels.Moderator
{
    public class MovieBindingModel : BaseBindingModel
    {
        [StringLength(128)]
        [Required]
        public string Title { get; set; }

        [StringLength(1024)]
        [Required]
        public string Description { get; set; }

        [Range(0, 500)]
        public int DurationInMinutes { get; set; }

        [DataType(DataType.ImageUrl)]
        public string CoverImageUrl { get; set; }

        [Url]
        public string TrailerVideoUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime PremiereDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DvdReleaseDate { get; set; }

        [Required]
        public MovieStatus Status { get; set; }

        public ICollection<GenreViewModel> Genres { get; set; }

        public ICollection<GenreViewModel> AllGenres { get; set; }

        public ICollection<PersonShortViewModel> Actors { get; set; }

        public ICollection<PersonShortViewModel> Directors { get; set; }

        public ICollection<PersonShortViewModel> Producers { get; set; }

        public ICollection<PersonShortViewModel> ScriptWriters { get; set; }

        public ICollection<PersonShortViewModel> AllPeople { get; set; }
    }
}
