using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Onboardr.Domain;
using Onboardr.Domain.DTOs;

namespace Onboadr.Infrastructure.Configuration
{
    public class MapperInitializer: Profile
    {
        public MapperInitializer()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, CreateCustomerDTO>().ReverseMap();
        }

    }
}
