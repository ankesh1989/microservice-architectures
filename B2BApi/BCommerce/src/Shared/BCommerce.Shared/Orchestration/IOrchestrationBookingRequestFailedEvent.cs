namespace BCommerce.Shared.Orchestration
{
    public interface IOrchestrationBookingRequestFailedEvent
    {
        public int OrderId { get; set; }
        public string Reason { get; set; }
    }
    public class OrchestrationBookingRequestFailedEvent : IOrchestrationBookingRequestFailedEvent
    {
        public OrchestrationBookingRequestFailedEvent(int orderId, string reason)
        {
            OrderId = orderId;
            Reason = reason;
        }

        public int OrderId { get; set; }
        public string Reason { get; set; }
    }
}
