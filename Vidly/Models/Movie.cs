using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        public string Name { get; set; }

        public MovieGenre MovieGenre { get; set; }

        [Display(Name = "Genre")]
        public int MovieGenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required(ErrorMessage = "Stock must be between 1 and 20.")]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int Stock { get; set; }
    }
}