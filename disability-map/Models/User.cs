namespace disability_map.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Login { get; set; }
        public required string Email { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public List<Score> Likes { get; set; } = new(); 
        public List<Score> DisLikes { get; set; } = new();
        public List<Place> MyPlaces { get; set; } = new();
        public string? ImagePath { get; set; }
    }
}
