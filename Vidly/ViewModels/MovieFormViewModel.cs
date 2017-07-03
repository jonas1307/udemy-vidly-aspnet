using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieFormViewModel
    {
        public MovieFormViewModel()
        {
            Movie = new Movie { Id = 0 };
        }

        public Movie Movie { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title
        {
            get { return (Movie.Id == 0 ? "New" : "Edit") + " Movie"; }
        }

    }
}