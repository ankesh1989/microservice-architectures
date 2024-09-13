using System.ComponentModel.DataAnnotations.Schema;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Entities
{
    public class BCOMSupplier:CommonTable
    {
        public string Code { get; set; }
        public string Name { get; set;}

        [ForeignKey("BCOMCountry")]
        public int CountryId { get; set; }
        public virtual BCOMCountry BCOMCountry { get; set; }

        [ForeignKey("BCOMState")]
        public int StateId { get; set; }
        public virtual BCOMState BCOMState { get; set; }
        [ForeignKey("BCOMCity")]
        public int cityId { get; set; }
        public virtual BCOMCity BCOMCity { get; set; }
        [ForeignKey("BCOMProduct")]
        public int ProductId { get; set; }
        public virtual BCOMProduct BCOMProduct { get; set; }
        public string LedgerCode { get; set; }
        public string Type { get; set; }
        public string Flex1 { get; set; }
        [ForeignKey("BCOMCurrency")]
        public int CurrencyId { get; set; }
        public virtual BCOMCurrency BCOMCurrency { get; set; }
        public string EndPoint1 { get; set; }
        public string EndPoint2 { get; set; }
        public string EndPoint3 { get; set; }
        public string EndPoint4 { get; set; }
        public string EndPoint5 { get; set; }
        public string EndPoint6 { get; set; }
        public string EndPoint7 { get; set; }
        public string Credentials1 { get; set; }
        public string Credentials2 { get; set; }
        public string Credentials3 { get; set; }
        public string Credentials4 { get; set; }
        public string Credentials5 { get; set; }
        public string Credentials6 { get; set; }
        public string Credentials7 { get; set; }
        public string Credentials8 { get; set; }
        public string Credentials9 { get; set; }
        public string Category { get; set; }
        public string Mode { get; set; }
        public string TechEmail { get; set; }
        public string TechContact { get; set; }
        public string SupplierAm { get; set; }
        public string SupplierAmContact { get; set; }
        public string ApiLastModified { get; set; }
        public string Remarks { get; set; }

    }
}
