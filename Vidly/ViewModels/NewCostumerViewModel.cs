using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class NewCostumerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Costumer Costumer { get; set; }
    }
}