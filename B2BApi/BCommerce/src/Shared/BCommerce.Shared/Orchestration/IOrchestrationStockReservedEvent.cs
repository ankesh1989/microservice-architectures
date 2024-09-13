namespace BCommerce.Shared.Orchestration
{
    public interface IOrchestrationStockReservedEvent : CorrelatedBy<Guid>
    {
        List<BookingItemMessage> OrderItems { get; set; }
    }
    public class OrchestrationStockReservedEvent : IOrchestrationStockReservedEvent
    {
        public OrchestrationStockReservedEvent(Guid correlationId)
        {
            CorrelationId = correlationId;
        }

        public List<BookingItemMessage> OrderItems { get; set; }
        public Guid CorrelationId { get; }
    }
}
