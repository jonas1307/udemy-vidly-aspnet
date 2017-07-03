﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Costumer
    {
        public int Id{ get; set; }

        [Required(ErrorMessage = "Please inform costumer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
    }
}