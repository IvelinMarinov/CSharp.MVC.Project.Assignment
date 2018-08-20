using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMovieDb.Models
{
    public class TheaterProgram
    {
        public TheaterProgram()
        {
            this.Movies = new HashSet<MoviesInTheater>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public ICollection<MoviesInTheater> Movies { get; set; }
    }
}
