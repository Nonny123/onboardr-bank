using Onboardr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.Services.Interface
{
    public interface IBankAccountService
    {
        Task<IList<BankAccount>> GetBankAccounts();
        Task<BankAccount> GetBankAccount(string accountNo);

        Task CreateBankAccount(BankAccount bankAccount);

        Task Deposit(string accountNo, decimal amountToDeposit);

        Task Withdraw(string accountNo, decimal amountToDeposit);
    }
}
