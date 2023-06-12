namespace disability_map.Models
{
    public class User
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required bool KeepLooggedIn { get; set; }
    }
}
