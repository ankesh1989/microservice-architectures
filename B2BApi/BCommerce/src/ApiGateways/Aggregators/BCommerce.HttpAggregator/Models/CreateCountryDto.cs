namespace BCommerce.HttpAggregator.Models
{
    public class CreateCountryDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int MarketId { get; set; }
        public string Nationality { get; set; }
        public string NationalityAR { get; set; }
    }
}