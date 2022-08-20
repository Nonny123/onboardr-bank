using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using onboadr_bank.DTOs.BankAccount;
using onboadr_bank.DTOs.Transaction;
using onboadr_bank.Services.Interface;
using Onboardr.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankAccountService _bankAccountService;        
        private readonly IMapper _mapper;


        public BankAccountController(IBankAccountService bankAccountService, IMapper mapper)
        {
            _bankAccountService = bankAccountService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get-accounts")]
        public async Task<IActionResult> GetBankAccounts()
        {
            try
            {
                var bankAccounts = await _bankAccountService.GetBankAccounts();
                var results = _mapper.Map<IList<BankAccountRequestDTO>>(bankAccounts);
                return Ok(results);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }



        [HttpGet("{id:int}", Name = "GetBankAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBankAccount(string accountNo)
        {

            var bankAccount = await _bankAccountService.GetBankAccount(accountNo);
            var result = _mapper.Map<BankAccountRequestDTO>(bankAccount);
            return Ok(result);

        }

        [HttpPost]
        [Route("create-account")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBankAccount([FromBody] CreateBankAccountRequestDTO createBankAccountRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bankAccount = _mapper.Map<BankAccount>(createBankAccountRequestDTO);
            await _bankAccountService.CreateBankAccount(bankAccount);

            return CreatedAtRoute("GetBankAccount", new { id = bankAccount.Id }, bankAccount);

        }


        [HttpPost]
        [Route("deposit")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Deposit([FromBody] TransactionOperationRequestDTO transactionOperationRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

  
            await _bankAccountService.Deposit(transactionOperationRequestDTO.AccountNo, transactionOperationRequestDTO.Amount);

            return Ok();

        }


        [HttpPost]
        [Route("withdraw")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Withdraw([FromBody] TransactionOperationRequestDTO transactionOperationRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            await _bankAccountService.Withdraw(transactionOperationRequestDTO.AccountNo, transactionOperationRequestDTO.Amount);

            return Ok();

        }

    }
}