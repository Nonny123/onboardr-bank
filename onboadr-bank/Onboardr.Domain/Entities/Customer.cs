
using System.ComponentModel.DataAnnotations;


namespace Onboardr.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string StateOfResidence { get; set; }

        [Required]
        [MaxLength(50)]
        public string LGA { get; set; }
    }
}
