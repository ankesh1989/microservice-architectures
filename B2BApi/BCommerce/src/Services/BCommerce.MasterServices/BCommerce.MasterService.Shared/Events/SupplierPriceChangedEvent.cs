namespace BCommerce.MasterService.Shared.Events
{
    public class SupplierPriceChangedEvent : IEvent
    {
        public Guid Id { get; set; }
        public decimal ChangedPrice { get; set; }
    }
}
