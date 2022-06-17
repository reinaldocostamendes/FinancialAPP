using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer
{
    public static class CashBookProducerConfiguration
    {
        public static void AddCashBookProducerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMessageProducer, RabbitMQProducer>();
        }
    }
}