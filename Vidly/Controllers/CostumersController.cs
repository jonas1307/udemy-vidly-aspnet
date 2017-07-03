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
                MembershipTypes = membershipTypes
            };

            return View("CostumerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Create(Costumer costumer)
        {
            _context.Costumers.Add(costumer);
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