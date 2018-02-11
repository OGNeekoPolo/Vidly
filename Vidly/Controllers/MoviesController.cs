using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Data;
using System.Data.Entity;

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
    }
}

