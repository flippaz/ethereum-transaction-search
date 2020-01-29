using EthereumTransactionSearch.Models.Provider;

namespace EthereumTransactionSearch.Api.Tests.Builders.Provider
{
    public class EthereumResponseBuilder : EthereumResponse
    {
        public EthereumResponseBuilder()
        {
            WithEthereumError(new EthereumErrorBuilder());
            WithEthereumResult(new EthereumResultBuilder());
        }

        public EthereumResponseBuilder WithEthereumError(EthereumError error)
        {
            Error = error;

            return this;
        }

        public EthereumResponseBuilder WithEthereumResult(EthereumResult result)
        {
            Result = result;

            return this;
        }
    }
}