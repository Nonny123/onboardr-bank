using System.ComponentModel.DataAnnotations;

namespace Onboardr.Domain.DTOs.Customer
{
    public class CreateCustomerDTO
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Phone number can not be longer than 50 characters")]
        public string PhoneNumber { get; set; }


        [Required]
        [EmailAddress(ErrorMessage = "Enter valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        [Required]
        public int StateId { get; set; }

        [Required]
        public int LgaId { get; set; }
    }
}
