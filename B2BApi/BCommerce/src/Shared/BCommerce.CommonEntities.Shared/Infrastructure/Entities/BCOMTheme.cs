
using System.ComponentModel.DataAnnotations;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMTheme:CommonTable
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
