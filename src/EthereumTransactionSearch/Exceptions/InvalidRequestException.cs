using System;

namespace EthereumTransactionSearch.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(string message)
        {
            ErrorMessage = message;
        }

        public string ErrorMessage { get; set; }
    }
}