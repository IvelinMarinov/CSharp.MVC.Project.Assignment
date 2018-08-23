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
    public class ModeratorGenreService : BaseService, IModeratorGenreService
    {
        public ModeratorGenreService(MyMovieDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public ICollection<GenreViewModel> GetAllGenres()
        {
            var genresDb = DbContext.Genres.ToList();

            var genres = Mapper.Map<ICollection<GenreViewModel>>(genresDb);

            return genres;
        }

        public GenreBindingModel Add(GenreBindingModel model)
        {
            if (DbContext.Genres.Any(g => g.Description == model.Description))
            {
                model.SetError("Genre already exists");
                return model;
            }

            var genre = Mapper.Map<Genre>(model);
            DbContext.Genres.Add(genre);
            DbContext.SaveChanges();

            Mapper.Map(genre, model);
            return model;
        }

        public GenreBindingModel GetGenreById(int id)
        {
            var genre = new GenreBindingModel();
            var genreDb = DbContext.Genres.Find(id);
            if (genreDb == null)
            {
                genre.SetError("No such genre in database");
                return genre;
            }

            genre = Mapper.Map<GenreBindingModel>(genreDb);
            return genre;
        }

        public GenreBindingModel EditGenre(GenreBindingModel model)
        {
            var genre = DbContext.Genres.Find(model.Id);

            if (genre == null)
            {
                model.SetError("No such genre in database");
                return model;
            }

            Mapper.Map(model, genre);

            DbContext.Genres.Update(genre);
            DbContext.SaveChanges();

            Mapper.Map(genre, model);
            return model;
        }

        public GenreBindingModel DeleteGenre(int id)
        {
            var model = new GenreBindingModel();
            var genre = DbContext.Genres.Find(id);

            if (genre == null)
            {
                model.SetError("No such person in database");
                return model;
            }

            DbContext.Genres.Remove(genre);
            DbContext.SaveChanges();

            Mapper.Map(genre, model);
            return model;
        }
    }
}
