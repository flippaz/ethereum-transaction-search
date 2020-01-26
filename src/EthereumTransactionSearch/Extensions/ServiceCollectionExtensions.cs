using EthereumTransactionSearch.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace EthereumTransactionSearch.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMvcServices(this IServiceCollection services)
        {
            services
                .AddControllersWithViews(options => { options.Filters.Add<ExceptionFilter>(); })
                .AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; });

            return services;
        }
    }
}