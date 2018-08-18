using System;
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
    public class ModeratorPersonService : BaseService, IModeratorPersonService
    {
        public ModeratorPersonService(MyMovieDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public ICollection<PersonShortViewModel> GetAllPeople()
        {
            var people = DbContext.People
                .Select(p => new PersonShortViewModel
                {
                    Id = p.Id,
                    FullName = $"{p.FirstName} {p.LastName}"
                })
                .ToList();

            return people;
        }

        public PersonBindingModel AddPerson(PersonBindingModel model)
        {
            try
            {
                var person = Mapper.Map<Person>(model);
                DbContext.People.Add(person);
                DbContext.SaveChanges();

                return model;
            }
            catch (Exception e)
            {
                model.SetError("A database error occured");
                return model;
            }
        }

        public PersonBindingModel GetPersonById(int id)
        {
            var model = new PersonBindingModel();

            var personDb = DbContext.People
                .Find(id);

            if (personDb == null)
            {
                model.SetError("No such person in database");
                return model;
            }

            model = Mapper.Map<PersonBindingModel>(personDb);
            return model;
        }

        public PersonBindingModel EditPerson(PersonBindingModel model)
        {
            var person = DbContext.People
                .Find(model.Id);

            if (person == null)
            {
                model.SetError("No such person in database");
                return model;
            }

            Mapper.Map(model, person);

            DbContext.People.Update(person);
            DbContext.SaveChanges();

            return model;
        }

        public PersonBindingModel DeletePerson(int id)
        {
            var model = new PersonBindingModel();
            var person = DbContext.People.Find(id);

            if (person == null)
            {
                model.SetError("No such person in database");
                return model;
            }

            DbContext.People.Remove(person);
            DbContext.SaveChanges();

            return model;
        }
    }
}
