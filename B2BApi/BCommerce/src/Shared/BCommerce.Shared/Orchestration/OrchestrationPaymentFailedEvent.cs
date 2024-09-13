namespace BCommerce.Shared.Orchestration
{
    public interface IOrchestrationPaymentFailedEvent : CorrelatedBy<Guid>
    {
        public string Reason { get; set; }
        public List<BookingItemMessage> OrderItems { get; set; }
    }
    public class OrchestrationPaymentFailedEvent
    {
        public OrchestrationPaymentFailedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public string Reason { get; set; }
        public List<BookingItemMessage> OrderItems { get; set; }

        public Guid CorrelationId { get; }
    }
}
