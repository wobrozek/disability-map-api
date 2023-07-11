using disability_map.Models;

namespace disability_map.Dtos
{
    public class GetByRadiusDto
    {
        public List<Double> LL { get; set; }
        public int Radius { get; set; } = 50;
        public List<PlaceType>? PlaceType { get; set; } = new();
    }
}
