using disability_map.DataAnnotations;

namespace disability_map.Models
{
    public class Reservation
    {

        public int Id { get; set; }
        public string PlaceId { get; set; }
        public Place Place { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        [FutureAnnotation]
        public long UnixTimestamp { get; set; }
        public long? Seq { get; set; }

    }
}
