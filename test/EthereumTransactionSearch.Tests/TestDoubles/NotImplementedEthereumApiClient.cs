using EthereumTransactionSearch.Clients;
using EthereumTransactionSearch.Models.Provider;
using System;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.Api.Tests.TestDoubles
{
    public class NotImplementedEthereumApiClient : IEthereumApiClient
    {
        public virtual Task<EthereumResponse> GetAllTransactionsByBlockNumber(string blockNumber)
        {
            throw new NotImplementedException();
        }
    }
}