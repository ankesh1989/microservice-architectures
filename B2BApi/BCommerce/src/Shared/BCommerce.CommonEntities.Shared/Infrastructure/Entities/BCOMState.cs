using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMState : CommonTable
    {
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }

        [ForeignKey("BCOMCountry")]
        public int CountryId { get; set; }
        public virtual BCOMCountry BCOMCountry { get; set; }
        public int LanguageId { get; set; }

    }
}