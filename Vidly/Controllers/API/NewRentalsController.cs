using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class NewRentalsController : ApiController
    {
        public ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto data)
        {
            var costumer = _context.Costumers.Single(f => f.Id == data.CostumerId);

            var movies = _context.Movies.Where(w => data.MoviesId.Contains(w.Id));

            foreach (var item in movies)
            {
                if (item.NumberInStock == 0)
                    return BadRequest("Requested movie is not avaliable.");

                item.NumberInStock--;

                _context.Rentals.Add(new Rental
                {
                    Costumer = costumer,
                    Movie = item,
                    DateOfRent = DateTime.Now
                });

                _context.SaveChanges();
            }

            return Ok();
        }
    }
}