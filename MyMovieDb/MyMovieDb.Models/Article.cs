using System;
using System.ComponentModel.DataAnnotations;

namespace MyMovieDb.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public User Author { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}