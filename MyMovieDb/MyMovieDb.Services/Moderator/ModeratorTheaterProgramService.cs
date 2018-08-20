using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Common.ViewModels.Moderator;
using MyMovieDb.Data;
using MyMovieDb.Models;
using MyMovieDb.Services.Moderator.Interfaces;

namespace MyMovieDb.Services.Moderator
{
    public class ModeratorTheaterProgramService : BaseService, IModeratorTheaterProgramService
    {
        public ModeratorTheaterProgramService(MyMovieDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public ICollection<TheaterProgramShortListViewModel> GetAll()
        {
            var programsDb = DbContext.TheaterProgram.ToList();

            var programs = Mapper.Map<ICollection<TheaterProgramShortListViewModel>>(programsDb);

            return programs;
        }

        public TheaterProgramBindingModel Add(TheaterProgramBindingModel model)
        {
            var program = Mapper.Map<TheaterProgram>(model);

            DbContext.TheaterProgram.Add(program);
            DbContext.SaveChanges();

            foreach (var movieId in model.SelectedMoviesIds)
            {
                DbContext.Add(new MoviesInTheater
                {
                    MovieId = movieId,
                    TheaterProgramId = program.Id
                });
            }
            DbContext.SaveChanges();

            return model;
        }

        public TheaterProgramBindingModel GetById(int id)
        {
            var model = new TheaterProgramBindingModel();
            var programDb = DbContext.TheaterProgram.Find(id);
            if (programDb == null)
            {
                model.SetError("Theater program not found in database");
                return model;
            }

            model = Mapper.Map<TheaterProgramBindingModel>(programDb);
            return model;
        }

        public TheaterProgramBindingModel Edit(TheaterProgramBindingModel model)
        {
            var programDb = DbContext.TheaterProgram.Find(model.Id);

            if (programDb == null)
            {
                model.SetError("Program not found in database");
                return model;
            }

            Mapper.Map(model, programDb);

            DbContext.TheaterProgram.Update(programDb);
            DbContext.SaveChanges();

            return model;
        }
    }
}
