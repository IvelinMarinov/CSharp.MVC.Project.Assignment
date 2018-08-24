using System;
using System.ComponentModel.DataAnnotations;
using MyMovieDb.Common.BindingModels;

namespace MyMovieDb.Common.ViewModels.Users
{
    public class MovieVoteBindingModel : BaseModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public int MovieId { get; set; }

        [Required]
        [Range(1, 10)]
        public int Vote { get; set; }

        public DateTime CreatedDate => DateTime.Now;
    }
}
