using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<MovieGenre> MovieGenres { get; set; }

        public int? MovieId { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Genre")]
        public int? MovieGenreId { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }


        [Required(ErrorMessage = "Stock must be between 1 and 20.")]
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int? Stock { get; set; }

        public string Title => MovieId != 0 ? "Edit Movie" : "New Movie";

        public MovieFormViewModel(Movie movie)
        {
            MovieId = movie.MovieId;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            Stock = movie.Stock;
            MovieGenreId = movie.MovieGenreId;
        }

        public MovieFormViewModel()
        {
            MovieId = 0;
        }
    }
}