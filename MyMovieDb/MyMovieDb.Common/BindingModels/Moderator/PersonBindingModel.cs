using System;
using System.ComponentModel.DataAnnotations;
using MyMovieDb.Common.Enums;

namespace MyMovieDb.Common.BindingModels.Moderator
{
    public class PersonBindingModel: BaseBindingModel
    {
        [Display(Name = "First Name")]
        [StringLength(128)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(128)]
        [Required]
        public string LastName { get; set; }

        [StringLength(128)]
        public string Alias { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Place Of Birth")]
        [Required]
        public string PlaceOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [StringLength(1024)]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Biography { get; set; }

        [DataType(DataType.ImageUrl)]
        public string PhotoImageUrl { get; set; }
    }
}
