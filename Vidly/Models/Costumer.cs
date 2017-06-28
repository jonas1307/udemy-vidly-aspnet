﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Costumer
    {
        public int Id{ get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? Birthday { get; set; }
    }
}