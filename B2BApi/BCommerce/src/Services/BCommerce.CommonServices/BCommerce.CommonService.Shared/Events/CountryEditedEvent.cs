using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.CommonService.Shared.Events
{
    public class CountryEditedEvent : IEvent
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
