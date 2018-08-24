using System;
using System.ComponentModel.DataAnnotations;

namespace MyMovieDb.Models
{
    public class MovieVotes
    {
        public User User { get; set; }

        public string UserId { get; set; }

        public Movie Movie { get; set; }

        public int MovieId { get; set; }

        [Required]
        public int Vote { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
