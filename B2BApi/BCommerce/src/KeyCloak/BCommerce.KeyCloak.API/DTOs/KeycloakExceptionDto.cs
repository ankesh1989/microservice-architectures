namespace BCommerce.KeyCloak.API.DTOs
{
    public class KeycloakExceptionDto : Exception
    {
        public KeycloakExceptionDto() { }

        public KeycloakExceptionDto(string message) : base(message) { }

        public KeycloakExceptionDto(string message, Exception innerException) : base(message, innerException) { }
    }
}
