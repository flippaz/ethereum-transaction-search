using EthereumTransactionSearch.Clients;
using EthereumTransactionSearch.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace EthereumTransactionSearch.Api.Tests.TestDoubles
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEthereumApiClient(this IServiceCollection services, IConfigurationRoot configuration, EthereumApiClientSettings settings)
        {
            return services
                .AddEthereumApiClient(configuration)
                .Replace(ServiceDescriptor.Singleton<IOptions<EthereumApiClientSettings>>(new OptionsWrapper<EthereumApiClientSettings>(settings)));
        }

        public static IServiceCollection AddServices(this IServiceCollection services, EthereumApiClientSettings settings)
        {
            return services
                .AddServices()
                .Replace(ServiceDescriptor.Singleton<IOptions<EthereumApiClientSettings>>(new OptionsWrapper<EthereumApiClientSettings>(settings)));
        }
    }
}