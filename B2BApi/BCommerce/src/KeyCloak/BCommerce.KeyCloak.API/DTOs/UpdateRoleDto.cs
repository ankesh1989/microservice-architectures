using Newtonsoft.Json;

namespace BCommerce.KeyCloak.API.DTOs
{
    public class UpdateRoleDto
    {
        [JsonProperty("id")]
        public string RoleId { get; set; }

        [JsonProperty("name")]
        public string RoleName { get; set; }

        [JsonProperty("description")]
        public string RoleDescription { get; set; }
       
    }
}