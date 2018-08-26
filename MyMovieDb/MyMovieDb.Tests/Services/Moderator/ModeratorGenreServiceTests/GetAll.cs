using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMovieDb.Common.ViewModels.Moderator;
using MyMovieDb.Data;
using MyMovieDb.Models;
using MyMovieDb.Services.Moderator;
using MyMovieDb.Services.Moderator.Interfaces;
using MyMovieDb.Tests.Mocks;

namespace MyMovieDb.Tests.Services.Moderator.ModeratorGenreServiceTests
{
    [TestClass]
    public class GetAll
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
        public void GetAllReturnsCorrectType()
        {
            //Arrange
            this.dbContext.Genres.Add(new Genre { Description = "genre one" });
            this.dbContext.Genres.Add(new Genre { Description = "genre two" });
            this.dbContext.Genres.Add(new Genre { Description = "genre three" });
            this.dbContext.SaveChanges();

            //Act
            var genres = this.genreService.GetAllGenres();

            //Assert
            Assert.IsInstanceOfType(genres, typeof(List<GenreViewModel>));
        }

        [TestMethod]
        public void GetAllWorksCorrectlyWithAFewGenres()
        {
            //Arrange
            this.dbContext.Genres.Add(new Genre { Description = "genre one" });
            this.dbContext.Genres.Add(new Genre { Description = "genre two" });
            this.dbContext.Genres.Add(new Genre { Description = "genre three" });
            this.dbContext.SaveChanges();

            //Act
            var genres = this.genreService.GetAllGenres();

            //Assert
            Assert.AreEqual(3, genres.Count);
            Assert.IsNotNull(genres);
        }

        [TestMethod]
        public void GetAllWorksCorrectlyWithZeroGenres()
        {
            //Act
            var genres = this.genreService.GetAllGenres();

            //Assert
            Assert.AreEqual(0, genres.Count);
            Assert.IsNotNull(genres);
        }
    }
}
