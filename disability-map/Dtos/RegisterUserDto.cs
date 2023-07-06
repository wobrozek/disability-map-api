namespace disability_map.Dtos
{
    public class RegisterUserDto : IImageDto
    {
        public required string Login { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public IFormFile? Image { get; set; }
    }
}
