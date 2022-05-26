using CashBook_API_Client.Interface;
using CashBook_API_Client.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashBook_API_Client.Configuration
{
    public static class CashBookConfiguration
    {
        public static void AddCashBookConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CashBookOptions>(options =>
            {
                options.BaseAddress = configuration["CashBookConnection:BaseUrl"];
                options.CashBookPostEndPoint = configuration["CashBookConnection:EndPoint"];
            });
            services.AddHttpClient<ICashBookClient, CashBookClient>();
        }
    }
}