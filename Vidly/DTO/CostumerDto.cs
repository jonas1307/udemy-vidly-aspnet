using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;


namespace Vidly.Dto
{
    public class CostumerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please inform costumer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
    }
}