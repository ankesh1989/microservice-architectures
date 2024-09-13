namespace BCommerce.KeyCloak.API.DTOs
{
    public class LoginUserDto
    {
        public string username { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<object> requiredActions { get; set; }
        public bool emailVerified { get; set; }
        public List<object> groups { get; set; }
        public bool enabled { get; set; }

    }
}
