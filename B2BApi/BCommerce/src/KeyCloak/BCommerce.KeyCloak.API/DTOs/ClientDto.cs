using System.ComponentModel.DataAnnotations;

namespace BCommerce.KeyCloak.API.DTOs
{
    public class ClientDto
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; } = string.Empty;

        public string rootUrl { get; set; } = string.Empty;
        public string adminUrl { get; set; } = string.Empty;
        public string baseUrl { get; set; } = string.Empty;
        public bool enabled { get; set; }
        public string client_GUID { get; set; } = string.Empty;
        public string client_Id { get; set; }
        public string client_secret { get; set; } = string.Empty;
    }
}
