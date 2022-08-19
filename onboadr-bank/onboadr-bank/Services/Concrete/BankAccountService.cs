using Onboardr.Domain.Entities;
using Onboardr.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace onboadr_bank.Services.Concrete
{
    public class BankAccountService
    {

        private readonly IUnitOfWork _unitOfWork;

        public BankAccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }


        public async Task<IList<BankAccount>> BankAccounts()
        {
            return await _unitOfWork.BankAccounts.GetAll();
        }

        
        public async Task<BankAccount> GetBankAccount(string accountNo)
        {
            return await _unitOfWork.BankAccounts.Get(q => q.AccountNo == accountNo);
        }

        public async Task CreateBankAccount(BankAccount bankAccount)
        { 
            await _unitOfWork.BankAccounts.Insert(bankAccount);
            await _unitOfWork.Save();

        }


    }
}
