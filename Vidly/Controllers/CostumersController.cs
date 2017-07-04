using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CostumersController : Controller
    {
        private ApplicationDbContext _context;

        public CostumersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CostumerFormViewModel
            {
                Costumer = new Costumer(),
                MembershipTypes = membershipTypes
            };

            return View("CostumerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Costumer costumer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CostumerFormViewModel
                {
                    Costumer = costumer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CostumerForm", viewModel);
            }

            if (costumer.Id == 0)
            {
                _context.Costumers.Add(costumer);
            }
            else
            {
                var costumerInDb = _context.Costumers.First(f => f.Id == costumer.Id);

                // Microsoft approach to update all data
                //TryUpdateModel(costumerInDb);

                // DTO - Data Transfer Object - Scopes for Automapping updates

                costumerInDb.Name = costumer.Name;
                costumerInDb.Birthday = costumer.Birthday;
                costumerInDb.MembershipTypeId = costumer.MembershipTypeId;
                costumerInDb.IsSubscribedToNewsletter = costumer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Costumers");
        }

        public ActionResult Index()
        {
            var costumers = _context.Costumers.Include(x => x.MembershipType).ToList();

            var viewModel = new CostumerIndexViewModel { Costumers = costumers };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var costumer = _context.Costumers.Include(c => c.MembershipType).SingleOrDefault(s => s.Id == id);

            if (costumer == null)
                return HttpNotFound();

            var viewModel = new CostumerFormViewModel
            {
                Costumer = costumer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CostumerForm", viewModel);
        }
    }
}