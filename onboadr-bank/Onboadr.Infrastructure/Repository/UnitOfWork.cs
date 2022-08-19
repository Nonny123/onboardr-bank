using Onboadr.Infrastructure.Data;
using Onboardr.Domain.Entities;
using Onboardr.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Onboadr.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<BankAccount> _bankaccounts;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;

        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IGenericRepository<Customer> Customers => _customers ??= new GenericRepository<Customer>(_context);

        public IGenericRepository<BankAccount> BankAccounts => _bankaccounts ??= new GenericRepository<BankAccount>(_context);

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}