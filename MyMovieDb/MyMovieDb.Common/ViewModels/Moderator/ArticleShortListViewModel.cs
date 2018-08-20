using System;
using System.ComponentModel.DataAnnotations;
using MyMovieDb.Common.BindingModels;

namespace MyMovieDb.Common.ViewModels.Moderator
{
    public class ArticleShortListViewModel : BaseModel
    {
        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
