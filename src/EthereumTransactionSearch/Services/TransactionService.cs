using EthereumTransactionSearch.Clients;
using EthereumTransactionSearch.Exceptions;
using EthereumTransactionSearch.Models.Provider;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IEthereumApiClient _ethereumApiClient;
        private readonly ILogger<TransactionService> _logger;
        private readonly AsyncRetryPolicy _retryPolicy;

        public TransactionService(
            IEthereumApiClient ethereumApiClient,
            IOptions<EthereumApiClientSettings> settings,
            ILogger<TransactionService> logger)
        {
            _ethereumApiClient = ethereumApiClient;
            _logger = logger;

            _retryPolicy = CreateRetryPolicy(settings.Value.RetryIntervals, "Error communicating with provider Api");
        }

        public async Task<IEnumerable<EthereumTransaction>> GetTransactions(string blockNumber, string address)
        {
            EthereumResponse response = await _retryPolicy.ExecuteAsync(
                async () => await _ethereumApiClient.GetAllTransactionsByBlockNumber(blockNumber));

            if (response.Error != null)
            {
                throw new InvalidRequestException(response.Error.Message);
            }

            IEnumerable<EthereumTransaction> allTransactions = response.Result?.Transactions;

            if (allTransactions != null && !string.IsNullOrWhiteSpace(address))
            {
                return FilterTransactionsByAddress(allTransactions, address);
            }

            return allTransactions;
        }

        private static IEnumerable<EthereumTransaction> FilterTransactionsByAddress(IEnumerable<EthereumTransaction> allTransactions, string address)
        {
            return allTransactions.Where(t => t.From == address);
        }

        private AsyncRetryPolicy CreateRetryPolicy(IEnumerable<TimeSpan> retryIntervals, string errorMessage)
        {
            return Policy
                .Handle<Exception>(ex => !(ex is NotFoundException))
                .WaitAndRetryAsync(retryIntervals, (exception, timeSpan) => _logger.LogWarning(0, exception, errorMessage));
        }
    }
}