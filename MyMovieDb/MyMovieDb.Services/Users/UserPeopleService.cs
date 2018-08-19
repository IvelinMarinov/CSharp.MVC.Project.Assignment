using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMovieDb.Common.ViewModels.Users;
using MyMovieDb.Data;
using MyMovieDb.Services.Users.Interfaces;

namespace MyMovieDb.Services.Users
{
    public class UserPeopleService : BaseService, IUserPeopleService
    {
        public UserPeopleService(MyMovieDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public PersonDetailsViewModel GetPersonById(int id)
        {
            var model = new PersonDetailsViewModel();

            var personDb = DbContext.People
                .Include(p => p.MoviesActedIn).ThenInclude(ma => ma.Movie)
                .Include(p => p.MoviesDirected).ThenInclude(md => md.Movie)
                .Include(p => p.MoviesProduced).ThenInclude(mp => mp.Movie)
                .Include(p => p.MoviesWroteScriptFor).ThenInclude(mw => mw.Movie)
                .FirstOrDefault(p => p.Id == id);

            if (personDb == null)
            {
                model.SetError("No such person in database");
                return model;
            }

            model = Mapper.Map<PersonDetailsViewModel>(personDb);
            return model;
        }
    }
}
