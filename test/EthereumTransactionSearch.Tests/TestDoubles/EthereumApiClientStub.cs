using EthereumTransactionSearch.Models.Provider;
using System;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.Api.Tests.TestDoubles
{
    public class EthereumApiClientStub : NotImplementedEthereumApiClient
    {
        public override Task<EthereumResponse> GetAllTransactionsByBlockNumber(string blockNumber)
        {
            throw new NotImplementedException();
        }
    }
}