namespace disability_map.Models
{
    public class Cords
    {
        public int Id { get; set; }
        public Double Longitude { get; set; }

        public Double Latitude { get; set; }

        public string PlaceId { get; set; }

        public Place Place{ get; set; }
    }
}
