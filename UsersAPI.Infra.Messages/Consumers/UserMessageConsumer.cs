using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using UsersAPI.Domain.ValueObjects;
using UsersAPI.Infra.Messages.Services;
using UsersAPI.Infra.Messages.Settings;

namespace UsersAPI.Infra.Messages.Consumers
{
    public class UserMessageConsumer : BackgroundService
    {
        private readonly RabbitMQSettings? _rabbitMQSettings;
        private readonly EmailMessageService? _emailMessageService;

        public UserMessageConsumer(IOptions<RabbitMQSettings?> rabbitMQSettings, EmailMessageService emailMessageService)
        {
            _rabbitMQSettings = rabbitMQSettings.Value;
            _emailMessageService = emailMessageService;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory() { Uri = new Uri(_rabbitMQSettings.Url) };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(_rabbitMQSettings.Queue, durable: true, exclusive: false, autoDelete: false);

            //objeto utilizado para ler e processar a fila
            var consumer = new EventingBasicConsumer(channel);
            
            //criando o mecanismo para ler cada item da fila
            consumer.Received += async (sender, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var userMessageVO = JsonConvert.DeserializeObject<UserMessageVO>(message);

                if (userMessageVO != null)
                {
                    await _emailMessageService.SendEmailAsync(userMessageVO);
                }

                //removendo o item da fila
                channel.BasicAck(args.DeliveryTag, false);
            };

            //executando a leitura da fila
            channel.BasicConsume(_rabbitMQSettings.Queue, autoAck: false, consumer);

            return Task.CompletedTask;
        }        
    }
}
