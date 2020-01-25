using System;

namespace EthereumTransactionSearch.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string blockNumber)
            : this(null, blockNumber)
        {
        }

        public NotFoundException(Exception innerException, string blockNumber) : base($"An error occurred when retrieving transactions with {blockNumber}", innerException)
        {
        }
    }
}