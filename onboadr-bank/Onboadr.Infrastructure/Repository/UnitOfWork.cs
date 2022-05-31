using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Onboadr.Infrastructure.Data;
using Onboadr.Infrastructure.IRepository;
using Onboardr.Domain;

namespace Onboadr.Infrastructure.Repository
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
