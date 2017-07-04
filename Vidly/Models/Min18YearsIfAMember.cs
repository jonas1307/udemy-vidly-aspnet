using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var costumer = (Costumer)validationContext.ObjectInstance;

            if (costumer.MembershipTypeId == MembershipType.Unknown ||
                costumer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (costumer.Birthday == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - costumer.Birthday.Value.Year;

            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Costumer should be at least 18 to go on a membership.");
        }
    }
}