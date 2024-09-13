namespace BCommerce.Shared.Common.FailedEvents
{
    public class PaymentFailedEvent
    {
        public int OrderId { get; set; }
        public string BuyerId { get; set; }
        public string Message { get; set; }

        public List<BookingItemMessage> OrderItems { get; set; }
    }
}
