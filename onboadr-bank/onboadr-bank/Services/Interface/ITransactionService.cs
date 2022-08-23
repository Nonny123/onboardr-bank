using Onboardr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.Services.Interface
{
    public interface ITransactionService
    {
        Task<IList<Transaction>> GetTransactions();
        Task<Transaction> GetTransaction(int bankAccountId);

        Task<IList<Transaction>> GetRecentTransactions(int count);

        Task CreateTransaction(Transaction transaction);
    }
}
