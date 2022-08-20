using Onboardr.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Onboardr.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<BankAccount> BankAccounts { get; }
        IGenericRepository<Transaction> Transactions { get; }
        Task Save();
    }
}
