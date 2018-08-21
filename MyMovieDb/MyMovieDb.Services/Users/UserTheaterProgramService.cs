using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMovieDb.Common.ViewModels.Users;
using MyMovieDb.Data;
using MyMovieDb.Services.Users.Interfaces;

namespace MyMovieDb.Services.Users
{
public    class UserTheaterProgramService : BaseService, IUserTheaterProgramService
    {
        public UserTheaterProgramService(MyMovieDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public TheaterProgramViewModel GetMoviewPlayingNow()
        {
            var nowPlayingDb = DbContext.TheaterProgram
                .Include(tp => tp.Movies)
                .ThenInclude(mp => mp.Movie)
                .FirstOrDefault(tp => tp.DateFrom <= DateTime.Now && tp.DateTo > DateTime.Now);

            var nowPlaying = Mapper.Map<TheaterProgramViewModel>(nowPlayingDb);

            return nowPlaying;
        }
    }
}
