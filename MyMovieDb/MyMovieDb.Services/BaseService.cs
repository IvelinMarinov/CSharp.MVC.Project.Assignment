using AutoMapper;
using MyMovieDb.Data;

namespace MyMovieDb.Services
{
    public abstract class BaseService
    {
        protected BaseService(MyMovieDbContext dbContext, IMapper mapper)
        {
            this.DbContext = dbContext;
            this.Mapper = mapper;
        }

        protected MyMovieDbContext DbContext { get; private set; }

        protected IMapper Mapper { get; private set; }
    }
}
