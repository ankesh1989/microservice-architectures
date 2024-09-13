using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace EventBus
{
    public class RabbitMqService : IRabbitMqService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string ExchangeName = "order.exchange";
        private const string SupplierDetailsQueueName = "supplierdetails.queue";

        public RabbitMqService()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" }; // Update with your RabbitMQ server details
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Declare exchange
            _channel.ExchangeDeclare(ExchangeName, ExchangeType.Fanout);

            // Declare queue for SupplierDetailsEvent
            _channel.QueueDeclare(SupplierDetailsQueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            // Bind queue to exchange
            _channel.QueueBind(SupplierDetailsQueueName, ExchangeName, routingKey: "");
        }

        public void PublishOrderCreatedEvent(AirlineCreatedEvent airlineCreatedEvent)
        {
            var messageBody = Encoding.UTF8.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(airlineCreatedEvent));
            _channel.BasicPublish(exchange: ExchangeName, routingKey: "", basicProperties: null, body: messageBody);
        }

        public void SubscribeToSupplierDetailsEvent(Action<string, int> onMessageReceived)
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                onMessageReceived(message, 2);
            };

            _channel.BasicConsume(queue: SupplierDetailsQueueName, autoAck: true, consumer: consumer);
            //return 1;
        }

        public void PublishSupplierDetailsEvent(string supplierDetailsEvent)
        {
            var messageBody = Encoding.UTF8.GetBytes(supplierDetailsEvent);
            _channel.BasicPublish(exchange: ExchangeName, routingKey: "", basicProperties: null, body: messageBody);
        }
    }
}