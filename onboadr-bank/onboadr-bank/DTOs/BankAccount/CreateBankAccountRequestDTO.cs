using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.DTOs.BankAccount
{
    public class CreateBankAccountRequestDTO
    {
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CustomerId { get; set; }

        public int BankAccountTypeId { get; set; }

    }
}
