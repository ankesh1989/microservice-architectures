using System.ComponentModel.DataAnnotations.Schema;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMSupplierDocument:CommonTable
    {
        [ForeignKey("BCOMSupplier")]
        public int SupplierId { get; set; }
        public virtual BCOMSupplier BCOMSupplier { get; set; }
        public string DocumentPath {  get; set; }
    }
}
