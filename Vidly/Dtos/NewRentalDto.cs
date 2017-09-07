using System.Collections.Generic;

namespace Vidly.Dtos
{
    public class NewRentalDto
    {
        public int CostumerId { get; set; }

        public List<int> MoviesId { get; set; }
    }
}