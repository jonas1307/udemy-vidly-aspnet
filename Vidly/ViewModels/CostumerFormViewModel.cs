using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CostumerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Costumer Costumer { get; set; }
    }
}