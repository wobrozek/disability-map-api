namespace disability_map.Models
{
    public class User: Entity
    {
        public User(string email, string password, bool keepLooggedIn)
        {
            Email = email;
            Password = password;
            KeepLooggedIn = keepLooggedIn;
        }

        public required string Email { get; set; }
        public required string Password { get; set; }
        public required bool KeepLooggedIn { get; set; }
    }
}
