using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace EventBus;

public class DaprEventBus : IEventBus
{
    private const string PubSubName = "bcommerce-pubsub";
    private readonly DaprClient _dapr;
    private readonly ILogger _logger;

    private readonly IConnection _connection;
    private readonly IModel _channel;

    public DaprEventBus(DaprClient dapr, ILogger<DaprEventBus> logger)
    {
        _dapr = dapr;
        _logger = logger;
    }

    public DaprEventBus(string hostName)
    {
        var factory = new ConnectionFactory() { HostName = hostName };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(exchange: "events", type: ExchangeType.Direct);
    }

    public async Task PublishAsync<TEvent>(TEvent eventMessage)
    {
        // Logic to publish the event to RabbitMQ
        // The eventMessage can be serialized and sent to the message broker
        Console.WriteLine($"Publishing event: {typeof(TEvent).Name}");
    }

    public async Task SubscribeAsync<TEvent>(Action<TEvent> eventHandler)
    {
        // Logic to subscribe to events from RabbitMQ
        // The eventHandler is invoked when an event is received
    }

    public async Task PublishAsync(IntegrationEvent integrationEvent)
    {
        var topicName = integrationEvent.GetType().Name;

        _logger.LogInformation(
            "Publishing event {@Event} to {PubsubName}.{TopicName}",
            integrationEvent,
            PubSubName,
            topicName);

        // We need to make sure that we pass the concrete type to PublishEventAsync,
        // which can be accomplished by casting the event to dynamic. This ensures
        // that all event fields are properly serialized.
        await _dapr.PublishEventAsync(PubSubName, topicName, (object)integrationEvent);
    }

    public async Task PublishEventAsync<TEvent>(TEvent @event)
    {
        Console.WriteLine($"Publishing event: {typeof(TEvent).Name}");

        var message = JsonConvert.SerializeObject(@event);
        var body = Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(exchange: "events",
                              routingKey: "order.created",
                              basicProperties: null,
                              body: body);
    }

    public Task SubscribeEventAsync<TEvent>(Action<TEvent> eventHandler)
    {
        _channel.QueueDeclare(queue: "order.events", durable: false, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var orderEvent = JsonConvert.DeserializeObject<Action<TEvent>>(message);

            // Handle the order event
            //Console.WriteLine($"Received OrderCreatedEvent. AirlineId: {orderEvent.AirlineId}, SupplierId: {orderEvent.SupplierId}");
        };

        _channel.BasicConsume(queue: "order.events", autoAck: true, consumer: consumer);

        Console.WriteLine($"Subscribing to event: {typeof(TEvent).Name}");
        throw new NotImplementedException();
    }
}
