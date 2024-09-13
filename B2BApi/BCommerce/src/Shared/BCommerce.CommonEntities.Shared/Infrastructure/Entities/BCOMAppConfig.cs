
using System.ComponentModel.DataAnnotations.Schema;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMAppConfig:CommonTable
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        [ForeignKey("BCOMProduct")]
        public int ProductId { get; set; }
        public virtual BCOMProduct BCOMProduct { get; set; }
        [ForeignKey("BCOMSupplier")]
        public int SupplierId { get; set; }
        public virtual BCOMSupplier BCOMSupplier { get; set; }
        public bool BookingStatus { get; set; }
        public string AppKey { get; set;}
        public string AppValue { get; set;}
        [ForeignKey("BCOMFunction")]
        public int PageFunctionId { get; set; }
        public virtual BCOMFunction BCOMFunction { get; set; }


    }
}
