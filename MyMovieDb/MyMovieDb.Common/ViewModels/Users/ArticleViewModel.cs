using System;
using System.ComponentModel.DataAnnotations;
using MyMovieDb.Common.BindingModels;

namespace MyMovieDb.Common.ViewModels.Users
{
    public class ArticleViewModel : BaseModel
    {
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string AuthorName { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
