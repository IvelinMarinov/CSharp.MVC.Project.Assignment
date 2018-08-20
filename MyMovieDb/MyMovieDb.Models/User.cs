using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using MyMovieDb.Common.Enums;

namespace MyMovieDb.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Articles = new HashSet<Article>();
        }

        [StringLength(128)]
        public string FirstName { get; set; }

        [StringLength(128)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public ICollection<Article> Articles { get; set; }

        //TO DO add avatar
    }
}