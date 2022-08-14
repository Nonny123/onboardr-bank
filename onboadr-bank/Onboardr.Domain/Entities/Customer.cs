
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("StateId")]
        public int StateId { get; set; }

        public State State { get; set; }

        [ForeignKey("LgaId")]
        public int LgaId { get; set; }

        public Lga Lga { get; set; }


    }
}
