using System.Collections.Generic;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Moderator;

namespace MyMovieDb.Services.Moderator.Interfaces
{
    public interface IModeratorArticleService
    {
        ICollection<ArticleShortListViewModel> GetAllArticles();

        ArticleBindingModel AddArticle(ArticleBindingModel model);

        ArticleBindingModel GetArticleById(int id);

        ArticleBindingModel EditArticle(ArticleBindingModel model);

        ArticleBindingModel DeleteArticle(int id);
    }
}
