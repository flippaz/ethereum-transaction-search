using EthereumTransactionSearch.Clients;
using EthereumTransactionSearch.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace EthereumTransactionSearch.Api.Tests.TestDoubles
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddNotImplementedEthereumApiClient(this IServiceCollection services)
        {
            return services
                .AddSingleton<IEthereumApiClient, NotImplementedEthereumApiClient>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services, EthereumApiClientSettings settings)
        {
            return services
                .AddServices()
                .Replace(ServiceDescriptor.Singleton<IOptions<EthereumApiClientSettings>>(new OptionsWrapper<EthereumApiClientSettings>(settings)));
        }
    }
}