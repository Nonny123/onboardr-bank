using Onboadr.Infrastructure.Data;
using Onboadr.Infrastructure.Repository.Interface;
using Onboardr.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Onboadr.Infrastructure.Repository.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private IGenericRepository<Customer> _customers;

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

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}