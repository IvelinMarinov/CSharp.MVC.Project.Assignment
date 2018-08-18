using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyMovieDb.Common.Enums;

namespace MyMovieDb.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Genres = new HashSet<MovieGenres>();
            this.Actors = new HashSet<MovieActors>();
            this.Directors = new HashSet<MovieDirectors>();
            this.Producers = new HashSet<MovieProducers>();
            this.ScriptWriters = new HashSet<MovieScriptWriters>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        
        [Range(0, 500)]
        public int DurationInMinutes { get; set; }

        [DataType(DataType.ImageUrl)]
        public string CoverImageUrl { get; set; }

        [StringLength(11)]
        public string TrailerYoutubeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime PremiereDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DvdReleaseDate { get; set; }

        [Required]
        public MovieStatus Status { get; set; }

        public ICollection<MovieGenres> Genres { get; set; }

        public ICollection<MovieActors> Actors { get; set; }

        public ICollection<MovieDirectors> Directors { get; set; }

        public ICollection<MovieProducers> Producers { get; set; }

        public ICollection<MovieScriptWriters> ScriptWriters { get; set; }
    }
}
