﻿using System.ComponentModel.DataAnnotations;

namespace MovieApplication.Models.Domain
{
    public class MovieModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }

    }
}
