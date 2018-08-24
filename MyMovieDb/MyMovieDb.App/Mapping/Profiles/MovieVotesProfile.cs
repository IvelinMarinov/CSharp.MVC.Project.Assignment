using AutoMapper;
using MyMovieDb.Common.ViewModels.Users;
using MyMovieDb.Models;

namespace MyMovieDb.App.Mapping.Profiles
{
    public class MovieVotesProfile : Profile
    {
        public MovieVotesProfile()
        {
            CreateMap<MovieVotes, MovieVoteBindingModel>();
            CreateMap<MovieVoteBindingModel, MovieVotes>();
        }
    }
}
