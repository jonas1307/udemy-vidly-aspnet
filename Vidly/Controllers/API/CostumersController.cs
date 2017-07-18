using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CostumersController : ApiController
    {
        private ApplicationDbContext _context;

        public CostumersController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET /api/costumers
        public IEnumerable<CostumerDto> GetCostumers()
        {
            return _context.Costumers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Costumer, CostumerDto>);
        }

        // GET /api/costumers/1
        public IHttpActionResult GetCostumer(int id)
        {
            var costumer = _context.Costumers.FirstOrDefault(f => f.Id == id);

            if (costumer == null)
                return NotFound();

            return Ok(Mapper.Map<Costumer, CostumerDto>(costumer));
        }

        // POST /api/costumers
        [HttpPost]
        public IHttpActionResult CreateCostumer(CostumerDto costumerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var costumer = Mapper.Map<CostumerDto, Costumer>(costumerDto);

            _context.Costumers.Add(costumer);
            _context.SaveChanges();

            costumerDto.Id = costumer.Id;

            return Created(new Uri(Request.RequestUri + "/" + costumer.Id), costumerDto);
        }

        [HttpPut]
        public void UpdateCostumer(int id, CostumerDto costumerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var costumerInDb = _context.Costumers.SingleOrDefault(c => c.Id == id);

            if (costumerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(costumerDto, costumerInDb);

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
