using System.Collections.Generic;

namespace EthereumTransactionSearch.Models.Provider
{
    public class EthereumResult
    {
        public IEnumerable<EthereumTransaction> Transactions { get; set; }
    }
}