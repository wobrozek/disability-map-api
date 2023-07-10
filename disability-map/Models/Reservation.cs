namespace disability_map.Models
{
    public class Reservations
    {
        public int Id { get; set; }
        public string PlaceId { get; set; }

        public Place Place { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int UnixTimestamp { get; set; }
    }
}
