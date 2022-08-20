using onboadr_bank.Services.Interface;
using Onboardr.Domain.Entities;
using Onboardr.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.Services.Concrete
{
    public class CustomerService : ICustomerService
    {

        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<IList<Customer>> GetCustomers()
        {
            return await _unitOfWork.Customers.GetAll();
        }


        public async Task<Customer> GetCustomer(int id)
        {
            return await _unitOfWork.Customers.Get(q => q.Id == id);
        }

        public async Task CreateCustomer(Customer customer)
        {
            await _unitOfWork.Customers.Insert(customer);
            await _unitOfWork.Save();

        }


    }
}
