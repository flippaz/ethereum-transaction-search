using EthereumTransactionSearch.Clients;
using EthereumTransactionSearch.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Threading.Tasks;

namespace EthereumTransactionSearch.Api.Tests.Fixtures
{
    public class GetTransactionsFixture
    {
        private Action<IServiceCollection> _setup;

        public GetTransactionsFixture()
        {
            _setup = services => { };
        }

        public async Task<IActionResult> GetTransactions(string blockNumber, string address)
        {
            IServiceProvider provider = TestServiceProvider.CreateProvider(
                services => _setup(services));

            var controller = provider.GetRequiredService<TransactionController>();

            return await controller.GetTransactions(blockNumber, address);
        }

        public GetTransactionsFixture WithEthereumApiClient(IEthereumApiClient apiClient)
        {
            _setup += services => services.Replace(ServiceDescriptor.Singleton(apiClient));
            return this;
        }
    }
}