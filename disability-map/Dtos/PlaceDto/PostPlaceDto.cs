using disability_map.Models;

namespace disability_map.Dtos
{
    public class PostPlaceDto 
    {
        public string Name { get; set; }

        public Double[] LL { get; set; }

        public string Adress { get; set; }

        public string OpeningHours { get; set; }

        public PlaceType Type { get; set; }

        public string? ImagePath{ get; set; }

        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
