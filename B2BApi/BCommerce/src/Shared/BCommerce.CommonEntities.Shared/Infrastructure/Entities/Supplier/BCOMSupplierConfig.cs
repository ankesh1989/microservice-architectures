using System.ComponentModel.DataAnnotations.Schema;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMSupplierConfig : CommonTable
    {
        [ForeignKey("BCOMSupplier")]
        public int SupplierId { get; set; }
        public virtual BCOMSupplier BCOMSupplier { get; set; }
        public string Name {  get; set; }
        public string AppKey { get; set; }
        public string AppValue { get; set; }
        public string Description { get; set; }
        public string Flex1 { get; set; }
    }
}
