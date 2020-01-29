using EthereumTransactionSearch.Models.Provider;

namespace EthereumTransactionSearch.Api.Tests.Builders.Provider
{
    public class EthereumErrorBuilder : EthereumError
    {
        public EthereumErrorBuilder()
        {
            WithMessage(RandomBuilder.NextString());
        }

        public EthereumErrorBuilder WithMessage(string message)
        {
            Message = message;

            return this;
        }
    }
}