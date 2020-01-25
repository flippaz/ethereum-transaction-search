using System;
using System.Collections.Generic;

namespace EthereumTransactionSearch.Clients
{
    public class EthereumApiClientSettings
    {
        public EthereumApiClientSettings()
        {
            RetryIntervals = new[] { TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(500), TimeSpan.FromSeconds(1) };
        }

        public string EthereumApiUrl { get; set; }

        public string ProjectId { get; set; }

        public IReadOnlyCollection<TimeSpan> RetryIntervals { get; set; }
    }
}