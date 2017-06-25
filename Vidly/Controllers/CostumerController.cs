using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CostumerController : Controller
    {
        public ActionResult Index()
        {
            var viewModel = new CostumerIndexViewModel{ Costumers = FillCostumers() };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new CostumerIndexViewModel { Costumers = FillCostumers() };

            if (viewModel.Costumers.Any(a => a.Id == id))
            {
                return View(viewModel.Costumers.First(f => f.Id == id));
            }

            return HttpNotFound();
        }

        private List<Costumer> FillCostumers()
        {
            return new List<Costumer>
            {
                new Costumer {Id = 1, Name = "Jane Doe" },
                new Costumer {Id = 2, Name = "Mark Garret" },
                new Costumer {Id = 3, Name = "Francis J. Underwood" },
                new Costumer {Id = 4, Name = "Lana del Rey" },
            };
        }
    }
}