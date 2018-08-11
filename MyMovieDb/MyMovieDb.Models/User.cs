﻿using System;
using System.ComponentModel.DataAnnotations;
using MyMovieDb.Models.Enums;

namespace MyMovieDb.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [StringLength(256)]
        [Required]
        public string Username { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [StringLength(128)]
        public string FirstName { get; set; }

        [StringLength(128)]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        //TO DO add avatar
    }
}
