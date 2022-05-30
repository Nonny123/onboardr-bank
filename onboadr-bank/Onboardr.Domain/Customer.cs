using System;
using System.ComponentModel.DataAnnotations;

namespace Onboardr.Domain
{
    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(20, ErrorMessage = "Phone number can not be longer than 50 characters")]
        public string PhoneNumber { get; set; }


        [Required]
        [EmailAddress(ErrorMessage = "Enter valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string StateOfResidence { get; set; }

        [Required]
        [MaxLength(50)]
        public string LGA { get; set; }
    }
}
