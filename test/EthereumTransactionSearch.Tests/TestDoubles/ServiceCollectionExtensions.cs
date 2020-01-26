using EthereumTransactionSearch.Clients;
using Microsoft.Extensions.DependencyInjection;

namespace EthereumTransactionSearch.Api.Tests.TestDoubles
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEthereumApiClientStub(this IServiceCollection services)
        {
            return services
                .AddSingleton<IEthereumApiClient, EthereumApiClientStub>();
        }
    }
}