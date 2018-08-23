using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Moderator;
using MyMovieDb.Data;
using MyMovieDb.Models;
using MyMovieDb.Services.Moderator.Interfaces;

namespace MyMovieDb.Services.Moderator
{
    public class ModeratorArticleService : BaseService, IModeratorArticleService
    {
        public ModeratorArticleService(MyMovieDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public ICollection<ArticleShortListViewModel> GetAllArticles()
        {
            var articlesDb = DbContext.Articles
                .Include(a => a.Author)
                .ToList();

            var articles = Mapper.Map<ICollection<ArticleShortListViewModel>>(articlesDb);

            return articles;
        }

        public ArticleBindingModel AddArticle(ArticleBindingModel model)
        {
            var article = Mapper.Map<Article>(model);

            DbContext.Articles.Add(article);
            DbContext.SaveChanges();

            Mapper.Map(article, model);
            return model;
        }

        public ArticleBindingModel GetArticleById(int id)
        {
            var model = new ArticleBindingModel();
            var articleDb = DbContext.Articles.Find(id);
            if (articleDb == null)
            {
                model.SetError("No such article in database");
                return model;
            }

            model = Mapper.Map<ArticleBindingModel>(articleDb);
            return model;
        }

        public ArticleBindingModel EditArticle(ArticleBindingModel model)
        {
            var articleDb = DbContext.Articles.Find(model.Id);

            if (articleDb == null)
            {
                model.SetError("No such article in database");
                return model;
            }

            Mapper.Map(model, articleDb);

            DbContext.Articles.Update(articleDb);
            DbContext.SaveChanges();

            Mapper.Map(articleDb, model);
            return model;
        }

        public ArticleBindingModel DeleteArticle(int id)
        {
            var model = new ArticleBindingModel();
            var articleDb = DbContext.Articles.Find(id);

            if (articleDb == null)
            {
                model.SetError("No such article in database");
                return model;
            }

            DbContext.Articles.Remove(articleDb);
            DbContext.SaveChanges();

            Mapper.Map(articleDb, model);
            return model;
        }
    }
}
