using System.Collections.Generic;

namespace EthereumTransactionSearch.Models.Api
{
    public class ApiErrorResponse
    {
        public ICollection<ApiErrorItem> Errors { get; set; }

        public string Message { get; set; }
    }
}