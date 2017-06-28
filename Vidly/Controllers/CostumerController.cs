using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CostumerController : Controller
    {
        private Contexto _context;

        public CostumerController()
        {
            _context = new Contexto();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var costumers = _context.Costumers.Include(x => x.MembershipType).ToList();

            var viewModel = new CostumerIndexViewModel { Costumers = costumers };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var costumer = _context.Costumers.SingleOrDefault(s => s.Id == id);

            if (costumer == null)
                return HttpNotFound();

            return View(costumer);
        }
    }
}