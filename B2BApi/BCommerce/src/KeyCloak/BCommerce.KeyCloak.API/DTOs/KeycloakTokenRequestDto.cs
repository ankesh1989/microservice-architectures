using Newtonsoft.Json;

namespace BCommerce.KeyCloak.API.DTOs
{
    public class KeycloakTokenRequestDto
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }
    }
}
