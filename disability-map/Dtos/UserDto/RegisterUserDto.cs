using System.ComponentModel.DataAnnotations;

namespace disability_map.Dtos
{
    public class RegisterUserDto
    {
        [MinLength(3), MaxLength(10)]
        public required string Login { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? ImagePath { get; set; }
    }
}
