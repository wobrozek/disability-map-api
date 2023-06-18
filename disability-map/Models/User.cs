namespace disability_map.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public List<Score> Likes { get; set; } = new(); 
        public List<Score> DisLikes { get; set; } = new();
        public List<Place> MyPlaces { get; set; } = new();
        public required bool KeepLooggedIn { get; set; }
    }
}
