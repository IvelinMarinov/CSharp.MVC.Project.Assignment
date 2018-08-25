using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMovieDb.Common.ViewModels.Users;
using MyMovieDb.Data;
using MyMovieDb.Models;
using MyMovieDb.Services.Users.Interfaces;

namespace MyMovieDb.Services.Users
{
    public class UserMovieService : BaseService, IUserMovieService
    {
        public UserMovieService(MyMovieDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public MovieDetailsViewModel GetMovieById(int id)
        {
            var model = new MovieDetailsViewModel();

            var movieDb = DbContext.Movies
                .Include(m => m.Genres).ThenInclude(mg => mg.Genre)
                .Include(m => m.Actors).ThenInclude(ma => ma.Person)
                .Include(m => m.Directors).ThenInclude(md => md.Person)
                .Include(m => m.Producers).ThenInclude(mp => mp.Person)
                .Include(m => m.ScriptWriters).ThenInclude(mw => mw.Person)
                .Include(m => m.MovieVotes)
                .FirstOrDefault(p => p.Id == id);

            if (movieDb == null)
            {
                model.SetError("No such movie in database");
                return model;
            }

            model = Mapper.Map<MovieDetailsViewModel>(movieDb);
            if (model.VotesCount == default(int))
            {
                model.AverageRating = default(int);
            }
            return model;
        }

        public MovieVoteBindingModel AddEditMovieVote(MovieVoteBindingModel model)
        {
            var existingVote = DbContext.MovieVotes
                .FirstOrDefault(mv => mv.UserId == model.UserId && mv.MovieId == model.MovieId);

            if (existingVote == null)
            {
                var newVote = Mapper.Map<MovieVotes>(model);
                DbContext.MovieVotes.Add(newVote);
                DbContext.SaveChanges();
            }
            else
            {
                Mapper.Map(model, existingVote);
                DbContext.SaveChanges();
            }

            return model;
        }

        public int GetRatingForExistingVote(int movieId, string userId)
        {
            var existingVote = DbContext.MovieVotes
                .FirstOrDefault(mv => mv.UserId == userId && mv.MovieId == movieId);

            if (existingVote == null)
            {
                return -1;
            }

            return existingVote.Vote;
        }
    }
}
