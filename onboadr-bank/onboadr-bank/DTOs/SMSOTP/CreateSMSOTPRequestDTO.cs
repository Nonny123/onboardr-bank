using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.DTOs.SMSOTP
{
    public class CreateSMSOTPRequestDTO
    {
        public string UniqueUserName { get; set; }

        [Required]

        public string Message { get; set; }

        [Required]
        public string RecipientPhoneNumber { get; set; }

        [Required]
        public string FromPhoneNumber { get; set; }

        public int OTPExpiryInSeconds { get; set; }

        public DateTime timeOTPCodeGen { get; set; }
    }
}
