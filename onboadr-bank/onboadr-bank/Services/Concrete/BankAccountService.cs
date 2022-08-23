using Ardalis.GuardClauses;
using onboadr_bank.Services.Interface;
using Onboardr.Domain.Entities;
using Onboardr.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace onboadr_bank.Services.Concrete
{
    public class BankAccountService: IBankAccountService
{
        private readonly ITransactionService _transactionService;
        private readonly IUnitOfWork _unitOfWork;

        public BankAccountService(IUnitOfWork unitOfWork, ITransactionService transactionService)
        {
            _unitOfWork = unitOfWork;
            _transactionService = transactionService;

        }


        public async Task<IList<BankAccount>> GetBankAccounts()
        {
            return await _unitOfWork.BankAccounts.GetAll();
        }

        
        public async Task<BankAccount> GetBankAccount(string accountNo)
        {
            return await _unitOfWork.BankAccounts.Get(q => q.AccountNo == accountNo);
        }

        public async Task CreateBankAccount(BankAccount bankAccount)
        {
            bankAccount.AccountNo = GenerateAccountNo(10);
            bankAccount.CFId = GenerateGUID();
            await _unitOfWork.BankAccounts.Insert(bankAccount);
            await _unitOfWork.Save();

        }

        public async Task Deposit(string accountNo, decimal amountToDeposit)
        {
            Guard.Against.NegativeOrZero(amountToDeposit, nameof(amountToDeposit));
            Guard.Against.NullOrEmpty(accountNo, nameof(accountNo));
            Guard.Against.Null(amountToDeposit, nameof(amountToDeposit));

            var account = await GetBankAccount(accountNo);
            account.Balance += amountToDeposit;
            _unitOfWork.BankAccounts.UpdateProperty(account, x => x.Balance);
            await _unitOfWork.Save();
            

            //Create Transaction
            var transaction = new Transaction
            {
                OperationType = "Deposit",
                Amount = amountToDeposit,
                TransactionDate = DateTime.Now,
                BankAccountId = account.Id
            };

            await _transactionService.CreateTransaction(transaction);

        }

        public async Task Withdraw(string accountNo, decimal amountToWithdraw)
        {
            Guard.Against.NegativeOrZero(amountToWithdraw, nameof(amountToWithdraw));
            Guard.Against.NullOrEmpty(accountNo, nameof(accountNo));
            Guard.Against.Null(amountToWithdraw, nameof(amountToWithdraw));


            var account = await GetBankAccount(accountNo);
            account.Balance -= amountToWithdraw;
            _unitOfWork.BankAccounts.UpdateProperty(account, x => x.Balance);
            await _unitOfWork.Save();


            //Create Transaction
            var transaction = new Transaction
            {
                OperationType = "Withdraw",
                Amount = amountToWithdraw,
                TransactionDate = DateTime.Now,
                BankAccountId = account.Id
            };

            await _transactionService.CreateTransaction(transaction);

        }

        private static string GenerateAccountNo(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        private Guid GenerateGUID()
        {
            return Guid.NewGuid();
        }

    }
}
