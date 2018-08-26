using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Data;
using MyMovieDb.Models;
using MyMovieDb.Services.Moderator.Interfaces;
using MyMovieDb.Tests.Mocks;
using MyMovieDb.Services.Moderator;

namespace MyMovieDb.Tests.Services.Moderator.ModeratorGenreServiceTests
{
    [TestClass]
    public class Add
    {
        private MyMovieDbContext dbContext;
        private IModeratorGenreService genreService;

        [TestInitialize]
        public void Initialize()
        {
            this.dbContext = MockDbContext.GetDbContext();
            this.genreService = new ModeratorGenreService(this.dbContext, MockAutoMapper.GetMapper());
        }

        [TestMethod]
        public void AddReturnsCorrectType()
        {
            //Arrange
            var genre = new GenreBindingModel { Description = "genre one" };

            //Act 
            var result = this.genreService.Add(genre);

            //Assert
            Assert.IsInstanceOfType(result, typeof(GenreBindingModel));
        }

        [TestMethod]
        public void AddWorksCorrectlyWithValidGenre()
        {
            //Arrange
            var genre = new GenreBindingModel { Description = "genre one" };

            //Act 
            this.genreService.Add(genre);

            //Assert
            Assert.AreEqual(1, this.dbContext.Genres.Count());

            var genreDb = this.dbContext.Genres.FirstOrDefault();
            Assert.IsNotNull(genreDb);
            Assert.AreEqual("genre one", genreDb.Description);
        }

        [TestMethod]
        public void AddWorksCorrectlyWithDuplicateGenre()
        {
            //Arrange
            this.dbContext.Genres.Add(new Genre { Description = "genre one" });
            this.dbContext.SaveChanges();
            var duplicateGenre = new GenreBindingModel { Description = "genre one" };

            //Act
            var result = this.genreService.Add(duplicateGenre);

            //Assert
            Assert.IsTrue(result.HasError);
            Assert.AreEqual(result.Message, "Genre already exists");
        }

        [TestMethod]
        public void AddFailsWithInvalidGenre()
        {
            //Arrange 
            GenreBindingModel genre = null;

            //Act
            Action action = () => this.genreService.Add(genre);

            //Assert
            Assert.ThrowsException<InvalidOperationException>(action);
        }
    }
}
