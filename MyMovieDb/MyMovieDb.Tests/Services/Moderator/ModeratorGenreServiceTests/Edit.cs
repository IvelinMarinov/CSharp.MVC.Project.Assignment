using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyMovieDb.Common.BindingModels.Moderator;
using MyMovieDb.Data;
using MyMovieDb.Models;
using MyMovieDb.Services.Moderator;
using MyMovieDb.Services.Moderator.Interfaces;
using MyMovieDb.Tests.Mocks;

namespace MyMovieDb.Tests.Services.Moderator.ModeratorGenreServiceTests
{
    [TestClass]
    public class Edit
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
        public void EditWorksCorrectlyWithValidModel()
        {
            //Arrange
            this.dbContext.Genres.Add(new Genre { Description = "genre one" });
            this.dbContext.SaveChanges();
            var editedGenre = new GenreBindingModel { Id = 1, Description = "edited" };

            //Act
            var result = this.genreService.EditGenre(editedGenre);

            //Assert
            Assert.AreEqual("edited", result.Description);
        }

        [TestMethod]
        public void EditWorksCorrectlyWithDuplicate()
        {
            //Arrange
            this.dbContext.Genres.Add(new Genre { Description = "genre one" });
            this.dbContext.Genres.Add(new Genre { Description = "genre two" });
            this.dbContext.SaveChanges();
            var editedGenre = new GenreBindingModel { Id = 1, Description = "genre two" };

            //Act
            var result = this.genreService.EditGenre(editedGenre);

            //Assert
            Assert.IsTrue(result.HasError);
            Assert.AreEqual(result.Message, "Genre already exists");
        }

        [TestMethod]
        public void EditWorksCorrectlyWithNonExistentId()
        {
            //Arrange
            var invalidModel = new GenreBindingModel { Id = 0, Description = "invalid" };

            //Act
            var result = this.genreService.EditGenre(invalidModel);

            //Assert
            Assert.IsTrue(result.HasError);
            Assert.AreEqual(result.Message, "No such genre in database");
        }
    }
}
