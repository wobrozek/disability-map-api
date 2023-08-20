using disability_map.Models;

namespace disability_map.Dtos
{
    public class GetReservationByUser
    {
        public GetPlaceDto place{ get; set; }
        public long UnixTimestamp { get; set; }

        public long seq { get; set; }
    }
}
