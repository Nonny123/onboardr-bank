using AutoMapper;
using Onboardr.Domain.DTOs;
using Onboardr.Domain.Entities;

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
