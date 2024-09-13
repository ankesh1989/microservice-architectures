using Newtonsoft.Json;

namespace BCommerce.KeyCloak.API.DTOs
{
    public class ResetPasswordDto
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("temporary")]
        public bool Temporary { get; set; }

        [JsonProperty("id")]
        public string UserId { get; set; }
    }
}