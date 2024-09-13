
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMNationality : CommonTable
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        [ForeignKey("BCOMCountry")]
        public int CountryId { get; set; }
        public virtual BCOMCountry BCOMCountry { get; set; }
    }
}
