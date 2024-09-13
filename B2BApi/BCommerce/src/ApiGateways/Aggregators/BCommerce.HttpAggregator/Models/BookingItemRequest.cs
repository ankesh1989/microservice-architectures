namespace BCommerce.HttpAggregator.Models
{
    public class BookingItemRequest
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
