using System.ComponentModel.DataAnnotations;

namespace disability_map.Models
{
    public class Place : Entity
    {
        public Place(string name, string latitude, string longitude, string adress, string openingHours, string? phone, string? email)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
            Adress = adress;
            OpeningHours = openingHours;
            Phone = phone;
            Email = email;
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Latitude { get; set; }
        [Required]
        public string Longitude { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string OpeningHours { get; set; }
        
        public string? Phone{ get; set; }
        public string? Email { get; set; }

  
    }
}
