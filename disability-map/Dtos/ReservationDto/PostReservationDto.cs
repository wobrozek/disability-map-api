using disability_map.DataAnnotations;

namespace disability_map.Dtos
{
    public class PostReservationDto
    {
        public string PlaceId { get; set; }
        [FutureAnnotation]
        public long UnixTimestamp { get; set; }
    }
}
