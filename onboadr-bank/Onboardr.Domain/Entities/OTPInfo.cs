using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onboardr.Domain.Entities
{
    public class OTPInfo
    {
        public int Id { get; set; }

        [Required]
        public string UniqueUserName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Message { get; set; }

        [Required]
        [MaxLength(20)]
        public string RecipientPhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string FromPhoneNumber { get; set; }

        public int OTPExpiryInSeconds { get; set; }

        public DateTime timeOTPCodeGen { get; set; }

    }
}
