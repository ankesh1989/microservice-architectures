namespace BCommerce.MasterService.Shared.Events
{
    public class BookingNameChangedEvent :IEvent
    {
        public Guid Id { get; set; }
        public string ChangedName { get; set; }
    }
}
