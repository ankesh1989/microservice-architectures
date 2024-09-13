namespace BCommerce.KeyCloak.API.DTOs
{ 
    public class KeycloakSettingsDto
    {
        public string? BaseUrl { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
    }
}
