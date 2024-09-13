namespace BCommerce.Shared.Orchestration
{
    public interface IAirlineCreatedRequestEvent
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string NumericCode { get; set; }
        public string LogoFile { get; set; }
        public float Commission { get; set; }
        public float AgentCommission { get; set; }
        public float PLB { get; set; }
        public float AgentPLB { get; set; }
        public bool IsDomestic { get; set; }
        public bool IsLCC { get; set; }
        public string Remarks { get; set; }
        public bool eTicketEligible { get; set; }
        public bool eTicketManualPrice { get; set; }
        public decimal Surcharge { get; set; }
        public bool eTicketForImportPNR { get; set; }
        public decimal TransactionFee { get; set; }
        public string FareRules { get; set; }
        public int SupplierId { get; set; }
        public int ConsolidatorId { get; set; }
        public bool IsServiceTaxOnBaseFarePlusYQ { get; set; }
        public string CommissionType { get; set; }
        public string UA { get; set; }
        public string TA { get; set; }
        public string AirlineNameAR { get; set; }
    }
    public class AirlineCreatedRequestEvent : IAirlineCreatedRequestEvent
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string NumericCode { get; set; }
        public string LogoFile { get; set; }
        public float Commission { get; set; }
        public float AgentCommission { get; set; }
        public float PLB { get; set; }
        public float AgentPLB { get; set; }
        public bool IsDomestic { get; set; }
        public bool IsLCC { get; set; }
        public string Remarks { get; set; }
        public bool eTicketEligible { get; set; }
        public bool eTicketManualPrice { get; set; }
        public decimal Surcharge { get; set; }
        public bool eTicketForImportPNR { get; set; }
        public decimal TransactionFee { get; set; }
        public string FareRules { get; set; }
        public int SupplierId { get; set; }
        public int ConsolidatorId { get; set; }
        public bool IsServiceTaxOnBaseFarePlusYQ { get; set; }
        public string CommissionType { get; set; }
        public string UA { get; set; }
        public string TA { get; set; }
        public string AirlineNameAR { get; set; }
    }
}
