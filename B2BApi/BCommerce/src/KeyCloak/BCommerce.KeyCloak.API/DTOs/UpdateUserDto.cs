using Newtonsoft.Json;

namespace BCommerce.KeyCloak.API.DTOs
{
    public class UpdateUserDto
    {
        [JsonProperty("id")]
        public string UserId { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("requiredActions")]
        public List<object> RequiredActions { get; set; }

        [JsonProperty("groups")]
        public List<object> Groups { get; set; }

        [JsonProperty("emailVerified")]
        public bool EmailVerified { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AccessModel
    {
        public bool manageGroupMembership { get; set; }
        public bool view { get; set; }
        public bool mapRoles { get; set; }
        public bool impersonate { get; set; }
        public bool manage { get; set; }
    }

    public class Attribute
    {
        public string name { get; set; }
        public string displayName { get; set; }
        public bool required { get; set; }
        public bool readOnly { get; set; }
        public Validators validators { get; set; }
    }

    public class Email
    {
        [JsonProperty("ignore.empty.value")]
        public bool ignoreemptyvalue { get; set; }
    }

    public class UserProfileMetadata
    {
        public List<Attribute> attributes { get; set; }
        public List<object> groups { get; set; }
    }

    public class Validators
    {
        public Email email { get; set; }
    }


}
