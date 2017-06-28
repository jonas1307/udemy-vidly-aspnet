using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var costumers = new List<Costumer>
            {
                new Costumer{Name = "Costumer 1"},
                new Costumer{Name = "Costumer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Costumers = costumers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(i => i.Genre).SingleOrDefault(s => s.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        // GET /Movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            var movies = _context.Movies.Include(i => i.Genre).ToList();

            var viewModel = new MovieIndexViewModel() { Movies = movies };

            return View(viewModel);
        }

        //Novo routing
        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}