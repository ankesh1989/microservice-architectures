namespace BCommerce.StateMachineWorkerService.CustomState
{
    /// <summary>
    /// Bu sınıf tüm distributed transaction'ı yönettiğim yer
    /// Then: Business kodları yazacağınız yer
    /// </summary>
    public class OrderStateMachine : MassTransitStateMachine<OrderStateInstance>
    {
        public Event<IBookingCreatedRequestEvent> OrderCreatedRequestEvent { get; set; }
        public Event<IOrchestrationStockReservedEvent> StockReservedEvent { get; set; }
        public Event<IOrchestrationStockNotReservedEvent> StockNotReservedEvent { get; set; }
        public Event<IOrchestrationPaymentCompletedEvent> PaymentCompletedEvent { get; set; }
        public Event<IOrchestrationPaymentFailedEvent> PaymentFailedEvent { get; set; }

        public State OrderCreated { get; set; }
        public State StockReserved { get; set; }
        public State StockNotReserved { get; set; }
        public State PaymentCompleted { get; set; }
        public State PaymentFailed { get; set; }

        public OrderStateMachine()
        {
            InstanceState(p => p.CurrentState); 

            Event(() => OrderCreatedRequestEvent, eventCorrelationConfigurator =>
            {
                eventCorrelationConfigurator.CorrelateBy<int>(database => database.OrderId, @event => @event.Message.OrderId).SelectId(selector => Guid.NewGuid());
            });

            Event(() => StockReservedEvent, eventCorrelationConfigurator =>
            {
                eventCorrelationConfigurator.CorrelateById(context => context.Message.CorrelationId);
            });

            Event(() => StockNotReservedEvent, eventCorrelationConfigurator =>
            {
                eventCorrelationConfigurator.CorrelateById(context => context.Message.CorrelationId);
            });

            Event(() => PaymentCompletedEvent, eventCorrelationConfigurator =>
            {
                eventCorrelationConfigurator.CorrelateById(context => context.Message.CorrelationId);
            });

            Initially(
                 When(OrderCreatedRequestEvent)
                .Then(context =>
                {
                    context.Saga.BuyerId = context.Message.BuyerId;
                    context.Saga.OrderId = context.Message.OrderId;
                    context.Saga.CreatedDate = DateTime.Now;
                    context.Saga.CardName = context.Message.Payment.CardName;
                    context.Saga.CardNumber = context.Message.Payment.CardNumber;
                    context.Saga.CVV = context.Message.Payment.CVV;
                    context.Saga.Expiration = context.Message.Payment.Expiration;
                    context.Saga.TotalPrice = context.Message.Payment.TotalPrice;
                })
                .Then(context => 
                {
                    Console.WriteLine($"OrderCreatedRequestEvent before : {context.Saga}");
                })
                .Publish(context => new OrchestrationBookingCreatedEvent(context.CorrelationId.Value)
                {
                    OrderItems = context.Message.OrderItems
                }) 
                .TransitionTo(OrderCreated) 
                .Then(context =>
                {
                    Console.WriteLine($"OrderCreatedRequestEvent After : {context.Saga}");
                })
            );

            During(OrderCreated,
                When(StockReservedEvent)
                    .Send(new Uri($"queue:{RabbitQueueName.PaymentStockReservedRequestQueueName}"), context => new OrchestrationStockReservedRequestPayment(context.Message.CorrelationId)
                    {
                        OrderItems = context.Message.OrderItems,
                        Payment = new PaymentMessage
                        {
                            CardName = context.Saga.CardName, 
                            CardNumber = context.Saga.CardNumber,
                            CVV = context.Saga.CVV,
                            Expiration = context.Saga.Expiration,
                            TotalPrice = context.Saga.TotalPrice
                        },
                        BuyerId = context.Saga.BuyerId
                    })
                    .TransitionTo(StockReserved)
                    .Then(context =>
                    {
                        Console.WriteLine($"StockReservedEvent After : {context.Saga}");
                    }),

                When(StockNotReservedEvent)
                 .Publish(context => new OrchestrationBookingRequestFailedEvent(context.Saga.OrderId, context.Message.Reason))
                 .TransitionTo(StockNotReserved)
                 .Then(context =>
                 {
                     Console.WriteLine($"StockReservedEvent After : {context.Saga}");
                 })
           );

          During(StockReserved,

               When(PaymentCompletedEvent)
                  .Publish(context => new OrchestrationBookingRequestCompletedEvent(context.Saga.OrderId))
                  .TransitionTo(PaymentCompleted)
                  .Then(context =>
                  {
                      Console.WriteLine($"PaymentCompletedEvent After : {context.Message}");
                  })
                  .Finalize(),

               When(PaymentFailedEvent)
                  .Publish(context => new OrchestrationBookingRequestFailedEvent(context.Saga.OrderId, context.Message.Reason))
                  .Send(new Uri($"queue:{RabbitQueueName.StockRollBackMessageQueueName}"), context => new StockRollbackMessage(context.Message.OrderItems))
                  .TransitionTo(PaymentFailed)
                  .Then(context =>
                  {
                      Console.WriteLine($"PaymentFailedEvent After : {context.Message}");
                  })
           );

          SetCompletedWhenFinalized();

        } 
    }
}
