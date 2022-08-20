using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.DTOs.BankAccount
{
    public class BankAccountRequestDTO : CreateBankAccountRequestDTO
    {
        public int Id { get; set; }

    }

}
