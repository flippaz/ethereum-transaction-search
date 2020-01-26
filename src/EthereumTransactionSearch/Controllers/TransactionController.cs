using EthereumTransactionSearch.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{blockNumber}")]
        public async Task<IActionResult> GetTransactions(string blockNumber, [FromQuery]string address)
        {
            if (!blockNumber.StartsWith("0x") || address == null || !address.StartsWith("0x"))
            {
                return new BadRequestObjectResult("Block Number and/or Address must start with 0x");
            }

            return Ok(await _transactionService.GetTransactions(blockNumber, address));
        }
    }
}