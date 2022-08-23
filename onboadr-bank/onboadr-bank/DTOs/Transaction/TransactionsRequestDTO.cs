using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.DTOs.Transaction
{
    public class TransactionsRequestDTO
    {
        public int Id { get; set; }

        public string OperationType { get; set; }

        
        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; }

        public int BankAccountId { get; set; }
       
    }
}
