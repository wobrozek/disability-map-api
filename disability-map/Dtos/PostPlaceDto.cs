using disability_map.Models;

namespace disability_map.Dtos
{
    public class PostPlaceDto : IImageDto
    {
        public string Name { get; set; }

        public Double[] LL { get; set; }

        public string Adress { get; set; }

        public string OpeningHours { get; set; }

        public PlaceType Type { get; set; }

        public IFormFile? Image{ get; set; }

        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
}
