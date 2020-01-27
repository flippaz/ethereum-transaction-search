using EthereumTransactionSearch.Models.Provider;
using System.Linq;

namespace EthereumTransactionSearch.Api.Tests.Builders.Provider
{
    public class EthereumResultBuilder : EthereumResult
    {
        public EthereumResultBuilder()
        {
            WithTransactions(new EthereumTransactionBuilder());
        }

        public EthereumResultBuilder WithTransactions(params EthereumTransaction[] transactions)
        {
            Transactions = transactions.ToList();

            return this;
        }
    }
}