using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyMovieDb.Common.ViewModels.Users;
using MyMovieDb.Data;
using MyMovieDb.Models;
using MyMovieDb.Services.Users.Interfaces;

namespace MyMovieDb.Services.User
{
    public class UserSearchService : BaseService, IUserSearchService
    {
        public const string Actor = "Actor";
        public const string Director = "Director";
        public const string Producer = "Producer";
        public const string Writer = "Writer";

        public UserSearchService(MyMovieDbContext dbContext, IMapper mapper) 
            : base(dbContext, mapper)
        {
        }

        public SearchResultsViewModel SearchByNameOrTitle(string searchString)
        {
            var results = new SearchResultsViewModel { SearchString = searchString };

            var foundMovies = DbContext.Movies
                .Include(m => m.Genres)
                .ThenInclude(mg => mg.Genre)
                .Where(m => m.Title.ToLower().Contains(searchString.ToLower()))
                .ToList();

            foreach (var movie in foundMovies.OrderBy(m => m.Title))
            {
                var model = Mapper.Map<MovieSearchResultViewModel>(movie);
                model.Title = HighlightMatchedText(model.Title, searchString);
                results.MoviesFound.Add(model);
            }

            var foundPeople = DbContext.People
                .Include(p => p.MoviesActedIn)
                .Include(p => p.MoviesDirected)
                .Include(p => p.MoviesProduced)
                .Include(p => p.MoviesWroteScriptFor)
                .Where(p => p.FirstName.ToLower().Contains(searchString.ToLower()) ||
                            p.LastName.ToLower().Contains(searchString.ToLower()))
                .ToList();

            foreach (var person in foundPeople.OrderBy(p => p.FirstName))
            {
                var model = Mapper.Map<PersonSearchResultViewModel>(person);
                model.Note = GetPersonMovieRoles(person);
                model.Name = HighlightMatchedText(model.Name, searchString);
                results.PeopleFound.Add(model);
            }

            return results;
        }       

        private string HighlightMatchedText(string inputStr, string searchString)
        {
            var pattern = $@"{searchString}";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            var match = regex.Match(inputStr);

            var result = inputStr.Replace(match.Value, $"<span class=\"search-result\">{match.Value}</span>");

            return result;
        }

        private string GetPersonMovieRoles(Person person)
        {
            var roles = new Dictionary<string, int>
            {
                { Actor, person.MoviesActedIn.Count },
                { Director, person.MoviesDirected.Count },
                { Producer, person.MoviesProduced.Count },
                { Writer, person.MoviesWroteScriptFor.Count }
            };

            var rolesArr = roles.OrderByDescending(r => r.Value)
                .Where(r => r.Value > 0)
                .Select(r => r.Key);

            return string.Join(", ", rolesArr);
        }
    }
}
