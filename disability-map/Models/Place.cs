using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nanoid;

namespace disability_map.Models
{
    public class Place
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string PlaceId { get; set; } = Nanoid.Nanoid.Generate();

        [Required]
        public string Name { get; set; }
        [Required]
        public Double Latitude { get; set; }
        [Required]
        public Double Longitude { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string OpeningHours { get; set; }

        public PlaceType Type { get; set; }

        public User Owner { get; set; }
        public string? ImagePath { get; set; }

        public string? Phone{ get; set; }
        public string? Email { get; set; }

  
    }
}
