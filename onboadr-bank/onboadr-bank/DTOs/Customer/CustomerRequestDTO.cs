using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.DTOs.Customer
{
    public class CustomerRequestDTO : CreateCustomerRequestDTO
    {
        public int Id { get; set; }

    }
}
