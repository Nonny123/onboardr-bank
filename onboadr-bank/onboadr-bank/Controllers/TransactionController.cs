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

        public TransactionController(ITransactionService transactionService, IMapper mapper)
        {
            _transactionService = transactionService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get-all-transactions")]
        public async Task<IActionResult> GetTransactions()
        {
            try
            {
                var transactions = await _transactionService.GetTransactions();
                var results = _mapper.Map<IList<TransactionsRequestDTO>>(transactions);
                return Ok(results);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }


        [HttpGet]
        [Route("get-recent-transactions")]
        public async Task<IActionResult> GetRecentTransactions(int count)
        {
            try
            {
                var recentTransactions = await _transactionService.GetRecentTransactions(count);
                var results = _mapper.Map<IList<TransactionsRequestDTO>>(recentTransactions);
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
