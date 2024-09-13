namespace BCommerce.Shared.Common.CreatedEvents
{
    public interface IBookingCreatedRequestEvent
    {
        public int OrderId { get; set; }
        public string BuyerId { get; set; }
        public List<BookingItemMessage> BoookingItems { get; set; }

        public PaymentMessage Payment { get; set; }
    }
    public class BookingCreatedRequestEvent : IBookingCreatedRequestEvent
    {
        public int OrderId { get; set; }
        public string BuyerId { get; set; }
        public List<BookingItemMessage> BoookingItems { get; set; } = new List<BookingItemMessage>();
        public PaymentMessage Payment { get; set; }
    }
}
