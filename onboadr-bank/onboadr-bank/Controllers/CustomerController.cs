﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Onboardr.Domain.Entities;
using onboadr_bank.Services.Interface;
using onboadr_bank.DTOs.Customer;

namespace onboadr_bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IGetBanksService _getBanksService;
        private readonly IMapper _mapper;


        public CustomerController(ICustomerService customerService, IMapper mapper, IGetBanksService getBanksService)
        {
            _customerService = customerService;
            _mapper = mapper;
            _getBanksService = getBanksService;
        }

        [HttpGet]
        [Route("get-customers")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await _customerService.GetCustomers();
                var results = _mapper.Map<IList<CustomerRequestDTO>>(customers);
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

            var customer = await _customerService.GetCustomer(id);
            var result = _mapper.Map<CustomerRequestDTO>(customer);
            return Ok(result);

        }

        [HttpPost]
        [Route("register-customer")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequestDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                //get LgaId and check if it belongs to stateId
                //else return lga not matching

                return BadRequest(ModelState);
            }

            var customer = _mapper.Map<Customer>(customerDTO);
            await _customerService.CreateCustomer(customer);

            return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);

        }

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> ConfirmCustomerAccount([FromBody] string OTP)
        //{

        //}

        [HttpGet]
        [Route("get_bank-names")]
        public async Task<IActionResult> GetBanks()
        {
            try
            {
                var banks = await _getBanksService.GetBankDetails();
                //var results = _mapper.Map<IList<CustomerDTO>>(banks);
                return Ok(banks);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
       
    }
}