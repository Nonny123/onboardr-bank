using System;
using System.ComponentModel.DataAnnotations;

namespace Onboardr.Domain.DTOs
{
    public class CustomerDTO : CreateCustomerDTO
    {
        public int Id { get; set; }

    }
}
