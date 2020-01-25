using EthereumTransactionSearch.Exceptions;
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
            return Ok(await _transactionService.GetTransactions(blockNumber, address));

            //var ethDetail = new List<EthereumTransaction>
            //{
            //    new EthereumTransaction
            //    {
            //        BlockHash = "blockHash1",
            //        BlockNumber = "blockNumber1",
            //        From = "address1",
            //        Gas = "gas1",
            //        GasPrice = "gasPrice1",
            //        Hash = "hash1",
            //        TransactionIndex = "index1",
            //        Value = "value1"
            //    },
            //    new EthereumTransaction
            //    {
            //        BlockHash = "blockHash2",
            //        BlockNumber = "blockNumber2",
            //        From = "address2",
            //        Gas = "gas2",
            //        GasPrice = "gasPrice2",
            //        Hash = "hash2",
            //        TransactionIndex = "index2",
            //        Value = "value2"
            //    },
            //    new EthereumTransaction
            //    {
            //        BlockHash = "blockHash3",
            //        BlockNumber = "blockNumber3",
            //        From = "address1",
            //        Gas = "gas3",
            //        GasPrice = "gasPrice3",
            //        Hash = "hash3",
            //        TransactionIndex = "index3",
            //        Value = "value3"
            //    }
            //};

            //if (address != null && !string.IsNullOrWhiteSpace(address))
            //{
            //    return await Task.FromResult(Ok(ethDetail.Where(t => t.From == address)));
            //}

            //return await Task.FromResult(Ok(ethDetail));
        }
    }
}