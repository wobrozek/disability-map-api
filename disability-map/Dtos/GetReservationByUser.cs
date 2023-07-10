using disability_map.Models;

namespace disability_map.Dtos
{
    public class GetReservationByUser
    {
        public Place place{ get; set; }
        public int UnixTimestamp { get; set; }
    }
}
