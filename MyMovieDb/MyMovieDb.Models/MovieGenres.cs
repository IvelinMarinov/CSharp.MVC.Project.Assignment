using System.ComponentModel.DataAnnotations;

namespace MyMovieDb.Models
{
    public class MovieGenres
    {
        [Required]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        [Required]
        public int GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}
