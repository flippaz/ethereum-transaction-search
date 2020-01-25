using EthereumTransactionSearch.Models.Provider;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<EthereumTransaction>> GetTransactions(string blockNumber, string address);
    }
}