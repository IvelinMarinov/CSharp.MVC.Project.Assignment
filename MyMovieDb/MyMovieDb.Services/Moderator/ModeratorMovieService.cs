using System;
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

        public MovieBindingModel AddMovie(MovieBindingModel model)
        {
            //check null premiere date
            var duplicateMovie = DbContext.Movies
                .FirstOrDefault(m => m.Title == model.Title && m.PremiereDate == model.PremiereDate);

            if (duplicateMovie != null)
            {
                model.SetError("Movie already exists");
                return model;
            }

            var movie = Mapper.Map<Movie>(model);

            try
            {
                DbContext.Movies.Add(movie);
                DbContext.SaveChanges();

                AddGenresOfMovie(model.SelectedGenresIds, movie.Id);
                AddActorsInMovie(model.SelectedActorIds, movie.Id);
                AddDirectorsOfMovie(model.SelectedDirectorIds, movie.Id);
                AddProducersOfMovie(model.SelectedProducerIds, movie.Id);
                AddWritersOfMovie(model.SelectedScriptWriterIds, movie.Id);
            }
            catch (Exception e)
            {
                model.SetError("Database error");
                return model;
            }

            return model;
        }

        public MovieBindingModel GetMovieById(int id)
        {
            var model = new MovieBindingModel();

            var movieDb = DbContext.Movies
                .Include(m => m.Genres)
                .Include(m => m.Actors)
                .Include(m => m.Directors)              
                .Include(m => m.Producers)
                .Include(m => m.ScriptWriters)
                .FirstOrDefault(m => m.Id == id);

            if (movieDb == null)
            {
                model.SetError("No such movie in database");
                return model;
            }

            model = Mapper.Map<MovieBindingModel>(movieDb);
            return model;
        }

        public MovieBindingModel EditMovie(MovieBindingModel model)
        {
            var movieDb = DbContext.Movies
                .Include(m => m.Genres)
                .Include(m => m.Actors)
                .Include(m => m.Directors)
                .Include(m => m.Producers)
                .Include(m => m.ScriptWriters)
                .FirstOrDefault(m => m.Id == model.Id);

            if (movieDb == null)
            {
                model.SetError("No such movie in database");
                return model;
            }

            var genresToRemove = movieDb.Genres;
            var genresToKeep = model.SelectedGenresIds.Select(id => new MovieGenres {GenreId = id, MovieId = model.Id.Value});
            
            var actorsToRemove = movieDb.Actors;
            var actorsToKeep = model.SelectedActorIds.Select(id => new MovieActors {PersonId = id, MovieId = model.Id.Value});
            
            var directorsToRemove = movieDb.Directors;
            var directorsToKeep = model.SelectedDirectorIds.Select(id => new MovieDirectors { PersonId = id, MovieId = model.Id.Value });
            
            var producersToRemove = movieDb.Producers;
            var producersToKeep = model.SelectedProducerIds.Select(id => new MovieProducers { PersonId = id, MovieId = model.Id.Value });
       
            var writersToRemove = movieDb.ScriptWriters;
            var writersToKeep = model.SelectedScriptWriterIds.Select(id => new MovieScriptWriters { PersonId = id, MovieId = model.Id.Value });

            Mapper.Map(model, movieDb);

            try
            {
                DbContext.Movies.Update(movieDb);

                DbContext.MovieGenres.RemoveRange(genresToRemove);
                DbContext.MovieGenres.AddRange(genresToKeep);

                DbContext.MovieActors.RemoveRange(actorsToRemove);
                DbContext.MovieActors.AddRange(actorsToKeep);

                DbContext.MovieDirectors.RemoveRange(directorsToRemove);
                DbContext.MovieDirectors.AddRange(directorsToKeep);

                DbContext.MovieProducers.RemoveRange(producersToRemove);
                DbContext.MovieProducers.AddRange(producersToKeep);

                DbContext.MovieScriptWriters.RemoveRange(writersToRemove);
                DbContext.MovieScriptWriters.AddRange(writersToKeep);

                DbContext.SaveChanges();
            }
            catch (Exception e)
            {
                model.SetError("Databasee error");
                return model;
            }

            return model;
        }

        public MovieBindingModel DeleteMovie(int id)
        {
            var model = new MovieBindingModel();
            var movie = DbContext.Movies.Find(id);

            if (movie == null)
            {
                model.SetError("No such movie in database");
                return model;
            }

            DbContext.Movies.Remove(movie);
            DbContext.SaveChanges();

            return model;
        }

        private void AddGenresOfMovie(ICollection<int> selectedGenresIds, int movieId)
        {
            var collectionToAdd = new List<MovieGenres>();

            foreach (var genreId in selectedGenresIds.Distinct().ToList())
            {
                //check if genre exists and relation doesn't
                if (DbContext.Genres.Any(p => p.Id == genreId) &&
                    !DbContext.MovieActors.Any(ma => ma.PersonId == genreId && ma.MovieId == movieId))
                {
                    var item = new MovieGenres()
                    {
                        GenreId = genreId,
                        MovieId = movieId
                    };

                    collectionToAdd.Add(item);
                }
            }

            DbContext.MovieGenres.AddRange(collectionToAdd);
            DbContext.SaveChanges();
        }

        private void AddActorsInMovie(ICollection<int> selectedActorIds, int movieId)
        {
            var collectionToAdd = new List<MovieActors>();

            foreach (var actorId in selectedActorIds.Distinct().ToList())
            {
                //check if person exists and relation doesn't
                if (DbContext.People.Any(p => p.Id == actorId) &&
                    !DbContext.MovieActors.Any(ma => ma.PersonId == actorId && ma.MovieId == movieId))
                {
                    var item = new MovieActors
                    {
                        PersonId = actorId,
                        MovieId = movieId
                    };

                    collectionToAdd.Add(item);
                }
            }

            DbContext.MovieActors.AddRange(collectionToAdd);
            DbContext.SaveChanges();
        }

        private void AddDirectorsOfMovie(ICollection<int> selectedDirectorIds, int movieId)
        {
            var collectionToAdd = new List<MovieDirectors>();

            foreach (var directorId in selectedDirectorIds.Distinct().ToList())
            {
                //check if person exists and relation doesn't
                if (DbContext.People.Any(p => p.Id == directorId) &&
                    !DbContext.MovieDirectors.Any(ma => ma.PersonId == directorId && ma.MovieId == movieId))
                {
                    var item = new MovieDirectors()
                    {
                        PersonId = directorId,
                        MovieId = movieId
                    };

                    collectionToAdd.Add(item);
                }
            }

            DbContext.MovieDirectors.AddRange(collectionToAdd);
            DbContext.SaveChanges();
        }

        private void AddProducersOfMovie(ICollection<int> selectedProducerIds, int movieId)
        {
            var collectionToAdd = new List<MovieProducers>();

            foreach (var producerId in selectedProducerIds.Distinct().ToList())
            {
                //check if person exists and relation doesn't
                if (DbContext.People.Any(p => p.Id == producerId) &&
                    !DbContext.MovieProducers.Any(ma => ma.PersonId == producerId && ma.MovieId == movieId))
                {
                    var item = new MovieProducers()
                    {
                        PersonId = producerId,
                        MovieId = movieId
                    };

                    collectionToAdd.Add(item);
                }
            }

            DbContext.MovieProducers.AddRange(collectionToAdd);
            DbContext.SaveChanges();
        }

        private void AddWritersOfMovie(ICollection<int> selectedScriptWriterIds, int movieId)
        {
            var collectionToAdd = new List<MovieScriptWriters>();

            foreach (var writerId in selectedScriptWriterIds.Distinct().ToList())
            {
                //check if person exists and relation doesn't
                if (DbContext.People.Any(p => p.Id == writerId) &&
                    !DbContext.MovieProducers.Any(ma => ma.PersonId == writerId && ma.MovieId == movieId))
                {
                    var item = new MovieScriptWriters()
                    {
                        PersonId = writerId,
                        MovieId = movieId
                    };

                    collectionToAdd.Add(item);
                }
            }

            DbContext.MovieScriptWriters.AddRange(collectionToAdd);
            DbContext.SaveChanges();
        }
    }
}
