
using System.ComponentModel.DataAnnotations.Schema;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMExchangeRate:CommonTable
    {
        [ForeignKey("BCOMAgentProfile")]
        public int AgentId { get; set; }
        public virtual BCOMAgentProfile BCOMAgentProfile { get; set; }
        public string BaseCurrencyCode { get; set; }
        public string ToCurrencyCode { get; set; }
        public string BuyingRate { get; set; }
        public string SellingRate { get; set; }
        public string BufferType { get; set; }
        public string BufferValue { get; set; }
        public string AppliedRate { get; set; }
        public string Remarks { get; set; }
        public DateTime FromDate { get; set; }
        [ForeignKey("BCOMProduct")]
        public int ProductId { get; set; }
        public virtual BCOMProduct BCOMProduct { get; set; }
        [ForeignKey("BCOMSupplier")]
        public int SupplierId { get; set; }
        public virtual BCOMSupplier BCOMSupplier { get; set; }

    }
}
