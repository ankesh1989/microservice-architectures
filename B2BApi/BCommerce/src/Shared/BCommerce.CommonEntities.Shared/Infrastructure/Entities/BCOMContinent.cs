 
﻿
using System.ComponentModel.DataAnnotations;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMContinent : CommonTable
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
