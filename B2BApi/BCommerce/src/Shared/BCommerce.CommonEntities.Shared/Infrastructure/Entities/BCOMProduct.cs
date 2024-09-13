
using System.ComponentModel.DataAnnotations;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMProduct : CommonTable
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
        public string Type { get;set; }
    }
}
