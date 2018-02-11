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
            new Movie { Id = 1, Name = "Shrek"},
            new Movie { Id = 2, Name = "Wall-E"}
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

        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult Index()
        {
            var viewModel = new MoviesViewModel
            {
                Movies = movieList
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            foreach (var movie in movieList)
            {
                if (movie.Id == id)
                {
                    var viewMovie = new Movie
                    {
                        Name = movie.Name,
                        Id = movie.Id
                    };

                    return View(viewMovie);
                }
            }
            return HttpNotFound("Movie does not exist");
        }
    }
}



// Alternate way to return view is
// return new ViewResult();

//1st param: Action/Method
//2nd param: Controller
//3rd param: Any parameters that would need to be received by the action being redirected to
//return RedirectToAction("index", "Home", new { page = 1, sortBy = "Name" });


//public ActionResult Edit(int id)
//{
//    return Content("id=" + id);
//}


//public ActionResult Index(int? pageIndex, string sortBy)
//{
//    if (!pageIndex.HasValue)
//        pageIndex = 1;


//    if (String.IsNullOrWhiteSpace(sortBy))
//        sortBy = "Name";

//    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
//}
