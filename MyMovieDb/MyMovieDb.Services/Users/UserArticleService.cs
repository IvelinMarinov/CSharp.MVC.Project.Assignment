using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMovieDb.Common.ViewModels.Users;
using MyMovieDb.Data;
using MyMovieDb.Services.Users.Interfaces;

namespace MyMovieDb.Services.Users
{
    public class UserArticleService : BaseService, IUserArticleService
    {
        public UserArticleService(MyMovieDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public ICollection<ArticleViewModel> GetLastTenArticles()
        {
            var articlesDb = DbContext.Articles
                .Include(a => a.Author)
                .OrderByDescending(a => a.CreatedDate)
                .Take(10)
                .ToList();

            var articles = Mapper.Map<ICollection<ArticleViewModel>>(articlesDb);

            return articles;
        }

        public ArticleViewModel GetArticleById(int id)
        {
            var model = new ArticleViewModel();
            var articleDb = DbContext.Articles
                .Include(a => a.Author)
                .FirstOrDefault(a => a.Id == id);

            if (articleDb == null)
            {
                model.SetError("No such article in database");
                return model;
            }

            model = Mapper.Map<ArticleViewModel>(articleDb);
            return model;
        }
    }
}
