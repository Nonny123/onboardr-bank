﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.DTOs.Transaction
{
    public class TransactionOperationRequestDTO
    {
        public string AccountNo { get; set; }

        public decimal Amount { get; set; }
    }
}
