using System.ComponentModel.DataAnnotations.Schema;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMEventType:CommonTable
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        [ForeignKey("BCOMProduct")]
        public int ProductId { get; set; }
        public virtual BCOMProduct BCOMProduct { get; set; }
    }
}
