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

        public IHttpActionResult CreateNewRental(NewRentalDto data)
        {
            var costumerInDb = _context.Costumers.Single(f => f.Id == data.CostumerId);

            var moviesInDb = _context.Movies.Where(w => data.MoviesId.Contains(w.Id));

            foreach (var item in moviesInDb)
            {
                if (item.NumberInStock == 0)
                    return BadRequest("Movie is not avaliable.");
            }

            return Ok();
        }
    }
}