namespace BCommerce.Dapr.API.Dtos.Country
{
    public class GetCountriesDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int MarketId { get; set; }
        public string MarketName { get; set; }
        public string Nationality { get; set; }
        public string NationalityAR { get; set; }
       public DateTime CreatedOn { get; set; }
    }

    public class CreateCountryDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int MarketId { get; set; }
        public string Nationality { get; set; }
        public string NationalityAR { get; set; }
    }

    public class EditCountyDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int MarketId { get; set; }
        public string Nationality { get; set; }
        public string NationalityAR { get; set; }
    }
}