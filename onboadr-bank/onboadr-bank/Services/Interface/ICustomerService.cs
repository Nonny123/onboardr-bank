using Onboardr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.Services.Interface
{
    public interface ICustomerService
    {
        Task<IList<Customer>> GetCustomers();
        Task<Customer> GetCustomer(int id);

        Task CreateCustomer(Customer customer);
    }
}
