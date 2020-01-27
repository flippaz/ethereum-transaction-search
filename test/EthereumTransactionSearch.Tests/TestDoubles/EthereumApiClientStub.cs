using EthereumTransactionSearch.Models.Provider;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.Api.Tests.TestDoubles
{
    public class EthereumApiClientStub : NotImplementedEthereumApiClient
    {
        public EthereumApiClientStub()
        {
            EthereumResponse = new Stack<EthereumResponse>();
        }

        private Stack<EthereumResponse> EthereumResponse { get; set; }

        public override async Task<EthereumResponse> GetAllTransactionsByBlockNumber(string blockNumber)
        {
            return await Task.FromResult(EthereumResponse.Pop());
        }

        public EthereumApiClientStub WithTransactionsResponse(params EthereumResponse[] response)
        {
            EthereumResponse = new Stack<EthereumResponse>(response);

            return this;
        }
    }
}