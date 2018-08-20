using System;
using System.ComponentModel.DataAnnotations;

namespace MyMovieDb.Common.BindingModels.Moderator
{
    public class ArticleBindingModel : BaseModel
    {
        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Display(Name = "Image URL")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public string AuthorId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
