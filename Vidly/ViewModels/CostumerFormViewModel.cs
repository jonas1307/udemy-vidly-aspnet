using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CostumerFormViewModel
    {
        public CostumerFormViewModel()
        {
            Costumer = new Costumer { Id = 0 };
        }
        public string Title
        {
            get { return (Costumer.Id == 0 ? "New" : "Edit") + " Costumer"; }
        }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Costumer Costumer { get; set; }
    }
}