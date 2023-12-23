using System.Text;
using System.Text.Json;
using OrdersService.Dto;
using RabbitMQ.Client;

namespace OrdersService.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private IConfiguration _configuration;
        private IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQHost"],
                Port = int.Parse(_configuration["RabbitMQPort"])
            };

            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);
                _connection.ConnectionShutdown += RabbitMQ_ConnectionShutdown;

                Console.WriteLine("--> Connected to Message Bus");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"-->> could not connect to message bus {ex.Message}");
            }

        }



        public void PublishNewOrder(OrderPublishedDto orderPublishedDto)
        {
            var message = JsonSerializer.Serialize(orderPublishedDto);
            if (_connection.IsOpen)
            {
                Console.WriteLine($"--> Rabbit MQ open, sending message {message}");
                SendMessage(message);


            }
            else
            {
                Console.WriteLine("--> RabbitMQ connection is closed, not sending");
            }

        }

        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "trigger", routingKey: "", basicProperties: null, body: body);

            Console.WriteLine($"--> we have sent the mesage");

        }

        public void Dispose()
        {
            Console.WriteLine("MessageBus Disposed");
            if (_channel.IsOpen)
            {
                _channel.Close();
                _connection.Close();
            }


        }

        private void RabbitMQ_ConnectionShutdown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine("--> RabbitMQ Connection shutdown");
        }
    }
}