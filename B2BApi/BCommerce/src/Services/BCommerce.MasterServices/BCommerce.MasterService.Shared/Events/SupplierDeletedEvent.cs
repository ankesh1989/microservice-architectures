namespace BCommerce.MasterService.Shared.Events
{
    public class SupplierDeletedEvent : IEvent
    {
        public Guid Id { get; set; }
    }
}
