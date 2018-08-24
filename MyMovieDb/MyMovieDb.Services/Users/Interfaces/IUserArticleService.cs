using System.Collections.Generic;
using MyMovieDb.Common.ViewModels.Users;

namespace MyMovieDb.Services.Users.Interfaces
{
    public interface IUserArticleService
    {
        ICollection<ArticleViewModel> GetLastTenArticles();

        ArticleViewModel GetArticleById(int id);
    }
}
