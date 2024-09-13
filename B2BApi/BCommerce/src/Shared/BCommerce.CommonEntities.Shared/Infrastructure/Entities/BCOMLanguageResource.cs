using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMLanguageResource : CommonTable
    {

        [Required]
        public string Name { get; set; }
        public string Class { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        [ForeignKey("BCOMLanguage")]
        public int LanguageId { get; set; }
        public virtual BCOMLanguage BCOMLanguage { get; set; }

    }
}
