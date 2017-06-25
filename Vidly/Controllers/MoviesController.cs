using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
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
            return Content("id=" + id);
        }

        // GET /Movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            var movies = FillMovies();

            var viewModel = new MovieIndexViewModel() { Movies = movies };

            return View(viewModel);
        }

        //Novo routing
        [Route("movies/released/{year}/{month}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        private List<Movie> FillMovies()
        {
            return new List<Movie>
            {
                new Movie{ Id = 1, Name = "Lolita" },
                new Movie{ Id = 2, Name = "A Clockwork Orange" },
                new Movie{ Id = 3, Name = "Transpotting" }
            };
        }
    }
}