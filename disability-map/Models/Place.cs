using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace disability_map.Models
{
    public class Place
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string PlaceId { get; set; } = Nanoid.Nanoid.Generate();

        [Required, MinLength(3),MaxLength(10)]
        public string Name { get; set; }
        [Required]
        public Cords? Cords { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string OpeningHours { get; set; }

        public PlaceType Type { get; set; }

        public User? Owner { get; set; }

        public List<Reservation>? Reservations { get; set; } = new();
        public string? ImagePath { get; set; }
        [Phone]
        public string Phone{ get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

  
    }
}
