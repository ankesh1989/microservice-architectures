namespace BCommerce.KeyCloak.API.DTOs
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<object> RequiredActions { get; set; }
        public List<object> Groups { get; set; }
        public bool EmailVerified { get; set; }
        public bool Enabled { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
    }

    public class UserRepresentation
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool Enabled { get; set; }
        public bool EmailVerified { get; set; }
        public string RealmRoles { get; set; }
        public List<CredentialRepresentation> Credentials { get; set; }
        public List<AttributeRepresentation> Attributes { get; set; }
        // Other user properties specific to Keycloak

        // Constructors, methods, or additional properties can be added as needed
    }

    public class CredentialRepresentation
    {
        public string Type { get; set; }
        public string Value { get; set; }
        // Other credential properties specific to Keycloak
    }

    public class AttributeRepresentation
    {
        public string Name { get; set; }
        public List<string> Values { get; set; }
        // Other attribute properties specific to Keycloak
    }
}
