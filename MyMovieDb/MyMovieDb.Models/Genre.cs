using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyMovieDb.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [StringLength(128)]
        [Required]
        public string Description { get; set; }

        public ICollection<MovieGenres> Movies { get; set; }

    }
}
