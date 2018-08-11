using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MyMovieDb.Models.Enums;

namespace MyMovieDb.Models
{
    public class Person
    {
        public Person()
        {
            this.MoviesActedIn = new HashSet<MovieActors>();
            this.MoviesDirected = new HashSet<MovieDirectors>();
            this.MoviesProduced = new HashSet<MovieProducers>();
            this.MoviesWroteScriptFor = new HashSet<MovieScriptWriters>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(1024)]
        [Required]
        public string Biography { get; set; }

        [StringLength(128)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(128)]
        [Required]
        public string LastName { get; set; }

        [StringLength(128)]
        public string Alias { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public string PlaceOfBirth { get; set; }
        
        [Required]
        public Gender Gender { get; set; }

        [DataType(DataType.ImageUrl)]
        public string PhotoImageUrl { get; set; }

        public ICollection<MovieActors> MoviesActedIn { get; set; }

        public ICollection<MovieDirectors> MoviesDirected { get; set; }

        public ICollection<MovieProducers> MoviesProduced { get; set; }

        public ICollection<MovieScriptWriters> MoviesWroteScriptFor { get; set; }
    }
}
