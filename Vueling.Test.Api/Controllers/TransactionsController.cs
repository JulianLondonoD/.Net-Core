using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Vueling.Test.Entities;
using Vueling.Test.Services;

namespace Vueling.Test.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _service;
        public TransactionsController(ITransactionsService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IList<TransactionEntity> transactions = await _service.getTransactions();
            return Ok(transactions);
        }

        [HttpGet("{sku}")]
        public async Task<IActionResult> Get(string sku)
        {
            IList<TransactionEntity> transactions = await _service.getTransactions(sku);
            return Ok(transactions);
        }

        [HttpGet]
        [Route("GetSumaTotal/{sku}")]
        public async Task<IActionResult> GetSumaTotal(string sku)
        {
            TransactionEntity transaction = await _service.getSumaTotal(sku);
            return Ok(transaction);
        }
    }
}
