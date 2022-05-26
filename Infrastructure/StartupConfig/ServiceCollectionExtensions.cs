using Infrastructure.Context;
using Infrastructure.Context.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.StartupConfig
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceContext(this IServiceCollection services)
        {
            services.AddScoped<IServiceContext, ServiceContext>();
        }
    }
}