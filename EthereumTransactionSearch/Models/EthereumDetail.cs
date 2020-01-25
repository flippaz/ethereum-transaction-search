using System.Collections.Generic;

namespace EthereumTransactionSearch.Models
{
    public class EthereumDetail
    {
        public EthereumResult Result { get; set; }
    }

    public class EthereumResult
    {
        public IEnumerable<EthereumTransaction> Transactions { get; set; }
    }

    public class EthereumTransaction
    {
        public string BlockHash { get; set; }

        public string BlockNumber { get; set; }

        public string From { get; set; }

        public string Gas { get; set; }

        public string GasPrice { get; set; }

        public string Hash { get; set; }

        public string TransactionIndex { get; set; }

        public string Value { get; set; }
    }
}