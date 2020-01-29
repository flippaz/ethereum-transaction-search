using EthereumTransactionSearch.Api.Tests.TestDoubles;
using EthereumTransactionSearch.Clients;
using EthereumTransactionSearch.Controllers;
using EthereumTransactionSearch.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EthereumTransactionSearch.Api.Tests.Fixtures
{
    public class TestServiceProvider
    {
        public static IServiceProvider CreateProvider(Action<IServiceCollection> overrides, EthereumApiClientSettings ethereumApiClientSettings)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().Build();

            IServiceCollection services = new ServiceCollection()
                .AddLogging()
                .AddMvcServices()
                .AddServices(ethereumApiClientSettings)
                .AddEthereumApiClient(configuration, ethereumApiClientSettings)
                .AddTransient<TransactionController>();

            overrides.Invoke(services);

            return services.BuildServiceProvider(true);
        }
    }
}