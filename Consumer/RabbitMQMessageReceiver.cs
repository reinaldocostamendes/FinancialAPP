using CashBook_Application.Application.Interface;
using CashBookDomain.DTO;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQConsuer
{
    public class RabbitMQMessageReceiver : IHostedService
    {
        private readonly ICashBookApplication _cashBookApplication;

        public RabbitMQMessageReceiver(ICashBookApplication cashBookApplication)
        {
            _cashBookApplication = cashBookApplication;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            new Thread(PullMessage).Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void PullMessage()
        {
            var factory = new ConnectionFactory
            {
                HostName = "rabbitmq"
            };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("cashbooks", exclusive: false);
            var consumer = new EventingBasicConsumer(channel);
            while (true)
            {
                consumer.Received += (model, eventArgs) =>
                {
                    var body = eventArgs.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    CashBookDTO receivedCasBookDTO = (CashBookDTO)Newtonsoft.Json.JsonConvert.DeserializeObject<CashBookDTO>(message);
                    _cashBookApplication.AddCashBook(receivedCasBookDTO);
                    //  Console.WriteLine($"Message received: {message}");
                };

                channel.BasicConsume(queue: "cashbooks", autoAck: true, consumer: consumer);
                Thread.Sleep(1000000000);
            }
            // Console.ReadKey();
        }
    }
}