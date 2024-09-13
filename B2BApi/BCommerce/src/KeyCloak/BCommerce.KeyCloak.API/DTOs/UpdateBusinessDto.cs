namespace BCommerce.KeyCloak.API.DTOs
{
    public class UpdateBusinessDto
    {
        public string id { get; set; }
        public string clientId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string rootUrl { get; set; }
        public string adminUrl { get; set; }
        public string baseUrl { get; set; }
    }
}
