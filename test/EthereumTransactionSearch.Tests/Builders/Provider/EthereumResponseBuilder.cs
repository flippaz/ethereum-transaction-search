using EthereumTransactionSearch.Models.Provider;

namespace EthereumTransactionSearch.Api.Tests.Builders.Provider
{
    public class EthereumResponseBuilder : EthereumResponse
    {
        public EthereumResponseBuilder()
        {
            WithEthereumResult(new EthereumResultBuilder());
        }

        public EthereumResponseBuilder WithEthereumResult(EthereumResult result)
        {
            Result = result;

            return this;
        }
    }
}