using disability_map.DataAnnotations;
using disability_map.Models;
using System.ComponentModel.DataAnnotations;

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
        [PhoneAnnotation]
        public string? Phone { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }
    }
}
