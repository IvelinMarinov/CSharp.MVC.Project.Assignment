using System.ComponentModel.DataAnnotations;

namespace MyMovieDb.Common.BindingModels.Moderator
{
    public class GenreBindingModel : BaseModel
    {
        [Required]
        public string Description { get; set; }
    }
}
