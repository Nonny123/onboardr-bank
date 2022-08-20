using AutoMapper;
using onboadr_bank.DTOs.BankAccount;
using onboadr_bank.DTOs.Customer;
using Onboardr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerRequestDTO>().ReverseMap();
            CreateMap<Customer, CreateCustomerRequestDTO>().ReverseMap();
            CreateMap<BankAccount, BankAccountRequestDTO>().ReverseMap();
            CreateMap<BankAccount, CreateBankAccountRequestDTO>().ReverseMap();
        }
    }
}
