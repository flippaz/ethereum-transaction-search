using Microsoft.Extensions.DependencyInjection;

namespace EthereumTransactionSearch.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddSingleton<ITransactionService, TransactionService>();
        }
    }
}