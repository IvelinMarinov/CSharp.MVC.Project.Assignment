using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MyMovieDb.Common.ViewModels.Moderator;
using MyMovieDb.Data;
using MyMovieDb.Services.Moderator.Interfaces;

namespace MyMovieDb.Services.Moderator
{
    public class ModeratorMovieService : BaseService, IModeratorMovieService
    {
        public ModeratorMovieService(MyMovieDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper)
        {
        }

        public ICollection<MovieShortListModel> GetAllMovies()
        {
            var movies = DbContext.Movies
                            .Select(m => new MovieShortListModel
                            {
                                Id = m.Id,
                                Title = m.Title
                            })
                            .ToList();

            return movies;
        }
    }
}
