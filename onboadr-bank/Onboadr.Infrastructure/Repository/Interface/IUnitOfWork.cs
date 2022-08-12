using Onboardr.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Onboadr.Infrastructure.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Customer> Customers { get; }

        Task Save();
    }
}
