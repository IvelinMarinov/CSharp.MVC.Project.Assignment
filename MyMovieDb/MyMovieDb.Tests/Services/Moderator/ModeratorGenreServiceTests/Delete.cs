using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMovieDb.Data;
using MyMovieDb.Models;
using MyMovieDb.Services.Moderator;
using MyMovieDb.Services.Moderator.Interfaces;
using MyMovieDb.Tests.Mocks;

namespace MyMovieDb.Tests.Services.Moderator.ModeratorGenreServiceTests
{
    [TestClass]
    public class Delete
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
        public void DeleteWorksCorrectly()
        {
            //Arrange
            this.dbContext.Genres.Add(new Genre { Description = "genre one" });
            this.dbContext.SaveChanges();

            //Act
            var result = this.genreService.DeleteGenre(1);
            var all = this.genreService.GetAllGenres();


            //Assert
            Assert.AreEqual(0, this.dbContext.Genres.ToList().Count);
        }

        [TestMethod]
        public void DeleteWorksCorrectlyWithNonexistentId()
        {
            //Act
            var result = this.genreService.DeleteGenre(0);

            //Assert
            Assert.IsTrue(result.HasError);
            Assert.AreEqual(result.Message, "No such genre in database");
        }
    }
}
