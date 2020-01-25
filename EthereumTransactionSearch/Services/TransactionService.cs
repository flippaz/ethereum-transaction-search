using EthereumTransactionSearch.Clients;
using EthereumTransactionSearch.Models.Provider;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IEthereumApiClient _ethereumApiClient;

        public TransactionService(IEthereumApiClient ethereumApiClient)
        {
            _ethereumApiClient = ethereumApiClient;
        }

        public async Task<IEnumerable<EthereumTransaction>> GetTransactions(string blockNumber, string address)
        {
            EthereumResponse response = await _ethereumApiClient.GetAllTransactionsByBlockNumber(blockNumber);

            IEnumerable<EthereumTransaction> allTransactions = response.Result?.Transactions;

            if (allTransactions != null && !string.IsNullOrWhiteSpace(address))
            {
                return FilterTransactionsByAddress(allTransactions, address);
            }

            return allTransactions;
        }

        private static IEnumerable<EthereumTransaction> FilterTransactionsByAddress(IEnumerable<EthereumTransaction> allTransactions, string address)
        {
            return allTransactions.Where(t => t.From == address);
        }
    }
}