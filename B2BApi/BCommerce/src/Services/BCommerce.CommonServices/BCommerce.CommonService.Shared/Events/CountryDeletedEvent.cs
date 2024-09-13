using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCommerce.CommonService.Shared.Events
{
    public class CountryDeletedEvent : IEvent
    {
        public Guid Id { get; set; }    
    }
}
