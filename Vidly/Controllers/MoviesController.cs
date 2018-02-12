using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        #region Declarations
        private VidlyDbContext _context;

        public MoviesController()
        {
            _context = new VidlyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        #endregion


        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies
                .Include(c => c.MovieGenre)
                .ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {

            var movie = _context.Movies
                .Include(y => y.MovieGenre)
                .FirstOrDefault(x => x.MovieId == id);

            if (movie != null)
                return View(movie);

            return HttpNotFound(" -- Movie does not exist --");

        }

        public ActionResult New()
        {
            var movieGenres = _context.MovieGenres.ToList();

            var viewModel = new MovieFormViewModel
            {
                MovieGenres = movieGenres
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.MovieId == 0)
            {
                movie.DateAdded = DateTime.Today;

                _context.Movies.Add(movie);

            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.MovieId == movie.MovieId);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.MovieGenreId = movie.MovieGenreId;
                movieInDb.Stock = movie.Stock;

            }

            try
            {
                _context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {

                Console.WriteLine(e);
            }
            return RedirectToAction("Index", "Movies");

        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies
                .SingleOrDefault(c => c.MovieId == id);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                MovieGenres = _context.MovieGenres.ToList()
            };

            return View("MovieForm", viewModel);

        }
    }
}

