using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMCity : CommonTable
    {
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("BCOMCountry")]
        public int CountryId { get; set; }
        public virtual BCOMCountry BCOMCountry { get; set; }

        [ForeignKey("BCOMState")]
        public int StateId { get; set; }
        public virtual BCOMState BCOMState { get; set; }
    }
}