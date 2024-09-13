namespace BCommerce.Shared.Orchestration
{
    public interface IOrchestrationBookingRequestCompletedEvent
    {
        public int OrderId { get; set; }
    }
    public class OrchestrationBookingRequestCompletedEvent : IOrchestrationBookingRequestCompletedEvent
    {
        public OrchestrationBookingRequestCompletedEvent(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; set; }
    }
}
