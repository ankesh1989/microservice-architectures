namespace BCommerce.KeyCloak.API.DTOs
{
    public class KeycloakUserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string OneTimePassword { get; set; }
    }
}