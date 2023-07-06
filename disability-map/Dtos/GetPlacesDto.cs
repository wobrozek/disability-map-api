using disability_map.Migrations;
using disability_map.Models;

namespace disability_map.Dtos
{
    public class GetPlacesDto
    {
        public string PlaceId { get; set; }
        public CordsDto LL { get; set; }
    }
}
