 
﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMCountry : CommonTable
    {
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("BCOMMarket")]
        public int MarketId { get; set; }      
        public virtual BCOMMarket BCOMMarket { get; set; }
        public string Nationality { get; set; }
        public string NationalityAR { get; set; }
    }
}