using System.ComponentModel.DataAnnotations;

namespace MyMovieDb.Models
{
    public class MovieProducers
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MovieId { get; set; }

        public Movie Movie { get; set; }

        [Required]
        public int PersonId { get; set; }

        public Person Person { get; set; }

        public string Note { get; set; }
    }
}
