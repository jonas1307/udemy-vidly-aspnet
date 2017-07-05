using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CostumersController : ApiController
    {
        private ApplicationDbContext _context;

        public CostumersController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET /api/costumers
        public IEnumerable<Costumer> GetCostumers()
        {
            return _context.Costumers.ToList();
        }

        // GET /api/costumer/1
        public Costumer GetCostumer(int id)
        {
            var costumer = _context.Costumers.FirstOrDefault(f => f.Id == id);

            if (costumer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return costumer;
        }

        // POST /api/costumers
        [HttpPost]
        public Costumer CreateCostumer(Costumer costumer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Costumers.Add(costumer);
            _context.SaveChanges();

            return costumer;
        }

        [HttpPut]
        public void UpdateCostumer(int id, Costumer costumer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var costumerInDb = _context.Costumers.SingleOrDefault(c => c.Id == id);

            if (costumerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            costumerInDb.Name = costumer.Name;
            costumerInDb.Birthday = costumer.Birthday;
            costumerInDb.IsSubscribedToNewsletter = costumer.IsSubscribedToNewsletter;
            costumerInDb.MembershipTypeId = costumer.MembershipTypeId;

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCostumer(int id)
        {
            var costumerInDb = _context.Costumers.SingleOrDefault(c => c.Id == id);

            if (costumerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Costumers.Remove(costumerInDb);
            _context.SaveChanges();
        }
    }
}
