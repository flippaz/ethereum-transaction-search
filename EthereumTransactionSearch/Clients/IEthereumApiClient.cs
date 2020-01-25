using EthereumTransactionSearch.Models.Provider;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.Clients
{
    public interface IEthereumApiClient
    {
        Task<EthereumResponse> GetAllTransactionsByBlockNumber(string blockNumber);
    }
}