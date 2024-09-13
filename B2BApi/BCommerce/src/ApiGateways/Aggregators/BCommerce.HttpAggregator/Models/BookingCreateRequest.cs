namespace BCommerce.HttpAggregator.Models
{
    public class BookingCreateRequest
    {
        public string BuyerId { get; set; }
        public List<BookingItemRequest> bookingItems { get; set; }
        public PaymentRequest Payment { get; set; }
        public AddressRequest Address { get; set; }
    }
}
