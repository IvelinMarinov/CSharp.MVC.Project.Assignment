using AutoMapper;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Moderator;
using MyMovieDb.Models;

namespace MyMovieDb.App.Mapping.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleShortListViewModel>()
                .ForMember(dest => dest.AuthorName,
                    opts => opts.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));

            CreateMap<ArticleBindingModel, Article>();
            CreateMap<Article, ArticleBindingModel>();

        }
    }
}
