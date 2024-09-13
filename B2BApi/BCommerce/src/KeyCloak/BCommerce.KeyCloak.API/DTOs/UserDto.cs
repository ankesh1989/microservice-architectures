using System.ComponentModel.DataAnnotations;

namespace BCommerce.KeyCloak.API.DTOs
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; }= string.Empty;

        public string Password { get; set; }

        public string UserName { get; set; }

    }
}
