using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using onboadr_bank.DTOs.Transaction;
using onboadr_bank.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onboadr_bank.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        [HttpGet]
        [Route("get-transactions")]
        public async Task<IActionResult> GetBankAccounts()
        {
            try
            {
                var bankAccounts = await _transactionService.GetTransactions();
                var results = _mapper.Map<IList<TransactionsRequestDTO>>(bankAccounts);
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
