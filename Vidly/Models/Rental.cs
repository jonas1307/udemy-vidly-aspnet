using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Rental
    {
        public long Id { get; set; }

        [Required]
        public Costumer Costumer { get; set; }

        [Required]
        public Movie Movie { get; set; }

        public DateTime DateOfRent { get; set; }

        public DateTime? DateOfReturn { get; set; }
    }
}