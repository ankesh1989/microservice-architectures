namespace BCommerce.Shared.Common.CreatedEvents
{
    public class StockReservedEvent
    {
        public StockReservedEvent()
        {
            OrderItems = new List<BookingItemMessage>();
        }
        public int OrderId { get; set; }
        public string BuyerId { get; set; }
        public PaymentMessage Payment { get; set; }

        public List<BookingItemMessage> OrderItems { get; set; }
    }
}
