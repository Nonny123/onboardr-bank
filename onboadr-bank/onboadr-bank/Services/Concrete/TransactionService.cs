using onboadr_bank.Services.Interface;
using Onboardr.Domain.Entities;
using Onboardr.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace onboadr_bank.Services.Concrete
{
    public class TransactionService : ITransactionService
    {

        private readonly IUnitOfWork _unitOfWork;

        public TransactionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public async Task<IList<Transaction>> GetTransactions()
        {
            return await _unitOfWork.Transactions.GetAll();
        }

        public async Task<IList<Transaction>> GetRecentTransactions(int count)
        {
            return await _unitOfWork.Transactions.GetRecent(null, x => x.OrderByDescending(t => t.TransactionDate),count);
        }


        public async Task<Transaction> GetTransaction(int bankAccountId)
        {
            return await _unitOfWork.Transactions.Get(q => q.BankAccountId == bankAccountId);
        }

        public async Task CreateTransaction(Transaction transaction)
        {
            await _unitOfWork.Transactions.Insert(transaction);
            await _unitOfWork.Save();

        }


    }
}
