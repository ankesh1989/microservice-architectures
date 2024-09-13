using System.ComponentModel.DataAnnotations.Schema;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMLocation:CommonTable
    {
        [ForeignKey("BCOMAgentProfile")]
        public int AgentId { get; set; }
        public virtual BCOMAgentProfile BCOMAgentProfile { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Landphone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string TaxReg { get; set; }
        public string Intergration { get; set; }
        public string ParentAgentId { get; set; }
        public string LedgerCode { get; set; }
        public string Terms { get; set; }
        public string Address { get; set; }
        public string BaseCurrency { get; set; }

    }
}
