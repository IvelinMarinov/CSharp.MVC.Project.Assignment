using System;
using Microsoft.EntityFrameworkCore;
using MyMovieDb.Data;

namespace MyMovieDb.Tests.Mocks
{
    public static class MockDbContext
    {
        public static MyMovieDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<MyMovieDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new MyMovieDbContext(options);
        }
    }
}
