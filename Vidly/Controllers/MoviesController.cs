using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        List<Movie> movieList = new List<Movie>
        {
            new Movie { MovieId = 1, Name = "Shrek"},
            new Movie { MovieId = 2, Name = "Wall-E"}
        };

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie
            {
                Name = "Shrek!"
            };

            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1"},
                new Customer { Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            var viewModel = new VidlyViewModel
            {
                Movies = movieList
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            foreach (var movie in movieList)
            {
                if (movie.MovieId == id)
                {
                    var viewMovie = new Movie
                    {
                        Name = movie.Name,
                        MovieId = movie.MovieId
                    };

                    return View(viewMovie);
                }
            }
            return HttpNotFound("Movie does not exist");
        }
    }
}

