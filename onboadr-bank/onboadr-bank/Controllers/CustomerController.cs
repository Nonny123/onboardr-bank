using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Onboadr.Infrastructure.IRepository;
using Onboardr.Domain;
using Onboardr.Domain.DTOs;

namespace onboadr_bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        

        public CustomerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await _unitOfWork.Customers.GetAll();
                var results = _mapper.Map<IList<CustomerDTO>>(customers);
                return Ok(results);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }

       

        [HttpGet("{id:int}", Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCustomer(int id)
        {

            var customer = await _unitOfWork.Customers.Get(q => q.Id == id);
            var result = _mapper.Map<CustomerDTO>(customer);
            return Ok(result);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            { 
                return BadRequest(ModelState);
            }

            var customer = _mapper.Map<Customer>(customerDTO);
            await _unitOfWork.Customers.Insert(customer);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);

        }

        [HttpGet]
        public async Task<IActionResult> GetBanks()
        {
            try
            {
                bankss = _bankService.GetFinanceNews(0);
                var results = _mapper.Map<IList<CustomerDTO>>(banks);
                return Ok(results);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }
    }
}
