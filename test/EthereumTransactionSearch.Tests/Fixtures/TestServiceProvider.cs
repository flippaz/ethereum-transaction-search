using EthereumTransactionSearch.Api.Tests.TestDoubles;
using EthereumTransactionSearch.Clients;
using EthereumTransactionSearch.Controllers;
using EthereumTransactionSearch.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EthereumTransactionSearch.Api.Tests.Fixtures
{
    public class TestServiceProvider
    {
        public static IServiceProvider CreateProvider(Action<IServiceCollection> overrides, EthereumApiClientSettings ethereumApiClientSettings)
        {
            IServiceCollection services = new ServiceCollection()
                .AddLogging()
                .AddMvcServices()
                .AddServices(ethereumApiClientSettings)
                .AddNotImplementedEthereumApiClient()
                .AddTransient<TransactionController>();

            overrides.Invoke(services);

            return services.BuildServiceProvider(true);
        }
    }
}