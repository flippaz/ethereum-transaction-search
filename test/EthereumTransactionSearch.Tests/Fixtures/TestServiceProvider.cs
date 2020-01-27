using EthereumTransactionSearch.Api.Tests.TestDoubles;
using EthereumTransactionSearch.Controllers;
using EthereumTransactionSearch.Extensions;
using EthereumTransactionSearch.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EthereumTransactionSearch.Api.Tests.Fixtures
{
    public class TestServiceProvider
    {
        public static IServiceProvider CreateProvider(Action<IServiceCollection> overrides = null)
        {
            IServiceCollection services = new ServiceCollection()
                .AddLogging()
                .AddMvcServices()
                .AddServices()
                .AddNotImplementedEthereumApiClient()
                .AddTransient<TransactionController>();

            overrides?.Invoke(services);

            return services.BuildServiceProvider(true);
        }
    }
}