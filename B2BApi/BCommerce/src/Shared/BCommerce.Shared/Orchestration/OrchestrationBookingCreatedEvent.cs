namespace BCommerce.Shared.Orchestration
{
    public interface IOrchestrationBookingCreatedEvent : CorrelatedBy<Guid>
    {
        List<BookingItemMessage> OrderItems { get; set; }
    }

    public class OrchestrationBookingCreatedEvent : IOrchestrationBookingCreatedEvent
    {
        public OrchestrationBookingCreatedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public Guid CorrelationId { get; init; }

        public List<BookingItemMessage> OrderItems { get; set; }
    }
}
