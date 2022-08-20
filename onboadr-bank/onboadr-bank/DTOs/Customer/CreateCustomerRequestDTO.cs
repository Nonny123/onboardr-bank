using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.DTOs.Customer
{
    public class CreateCustomerRequestDTO
    {

        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Phone number can not be longer than 50 characters")]
        public string PhoneNumber { get; set; }


        [Required]
        [EmailAddress(ErrorMessage = "Enter valid email address")]
        public string Email { get; set; }

        [Required]
        public int StateId { get; set; }

        [Required]
        public int LgaId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
