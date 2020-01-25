using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EthereumTransactionSearch.Clients
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEthereumApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .Configure<EthereumApiClientSettings>(configuration)
                .AddSingleton<IEthereumApiClient, EthereumApiClient>();
        }
    }
}