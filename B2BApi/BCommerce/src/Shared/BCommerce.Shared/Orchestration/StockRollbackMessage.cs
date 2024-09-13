namespace BCommerce.Shared.Orchestration
{
    public interface IOrchestrationStockRollBackMessage
    {
        List<BookingItemMessage> OrderItems { get; set; }
    }

    public class StockRollbackMessage : IOrchestrationStockRollBackMessage
    {
        public StockRollbackMessage(List<BookingItemMessage> orderItems)
        {
            OrderItems = orderItems;
        }

        public List<BookingItemMessage> OrderItems { get; set; }
    }
}
