 
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMMarket : CommonTable
    {
        [Required]
        public string Name { get; set; }
        public string Code { get; set; }
        [ForeignKey("BCOMContinent")]
        public int ContinentId{ get; set; }
        public virtual BCOMContinent BCOMContinent { get; set; }
    }
}
