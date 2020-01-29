using EthereumTransactionSearch.Api.Tests.Builders;
using EthereumTransactionSearch.Clients;
using EthereumTransactionSearch.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.Api.Tests.Fixtures
{
    public class GetTransactionsFixture
    {
        private readonly EthereumApiClientSettings _ethereumApiClientSettings;
        private Action<IServiceCollection> _setup;

        public GetTransactionsFixture()
        {
            _setup = services => { };

            _ethereumApiClientSettings = new EthereumApiClientSettings
            {
                RetryIntervals = new TimeSpan[] { },
                EthereumApiUrl = RandomBuilder.NextUrlString(),
                ProjectId = RandomBuilder.NextString()
            };
        }

        public async Task<IActionResult> GetTransactions(string blockNumber, string address)
        {
            IServiceProvider provider = TestServiceProvider.CreateProvider(
                services => _setup(services), _ethereumApiClientSettings);

            var controller = provider.GetRequiredService<TransactionController>();

            return await controller.GetTransactions(blockNumber, address);
        }

        public GetTransactionsFixture WithEthereumApiClient(IEthereumApiClient apiClient)
        {
            _setup += services => services.Replace(ServiceDescriptor.Singleton(apiClient));

            return this;
        }

        public GetTransactionsFixture WithEthereumApiRetryIntervals(IReadOnlyCollection<TimeSpan> retryIntervals)
        {
            _ethereumApiClientSettings.RetryIntervals = retryIntervals;

            return this;
        }
    }
}