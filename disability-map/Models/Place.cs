using System.ComponentModel.DataAnnotations;

namespace disability_map.Models
{
    public class Place
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Latitude { get; set; }
        [Required]
        public string longitude { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string OpeningHours { get; set; }
        
        public string? Phone{ get; set; }
        public string? Email { get; set; }
    }
}
