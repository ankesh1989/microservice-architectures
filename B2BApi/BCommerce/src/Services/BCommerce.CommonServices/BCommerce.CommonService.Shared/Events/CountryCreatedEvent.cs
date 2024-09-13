using System.ComponentModel.DataAnnotations;

namespace BCommerce.CommonService.Shared.Events
{
    public class CountryCreatedEvent : IEvent
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid MarketId { get; set; }
        public string Nationality { get; set; }
        public string NationalityAR { get; set; }
    }
}
