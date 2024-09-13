namespace BCommerce.MasterService.Shared.Events
{
    public class SupplierNameChangedEvent : IEvent
    {
        public Guid Id { get; set; }
        public string ChangedName { get; set; }
    }
}
