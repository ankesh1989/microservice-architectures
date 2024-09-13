namespace BCommerce.Dapr.API.Dtos.Airline
{
    public class GetAirlineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int SupplierCountryId { get; set; }
        public string SupplierCountryName { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}