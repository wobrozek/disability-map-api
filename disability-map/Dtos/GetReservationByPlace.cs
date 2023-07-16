using disability_map.Models;

namespace disability_map.Dtos
{
    public class GetReservationByPlace
    {
        public UserContactDto User{ get; set; }
        public int UnixTimestamp { get; set; }

        public long seq { get; set; }
    }
}
