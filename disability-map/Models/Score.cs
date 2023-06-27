using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace disability_map.Models
{
    public class Score
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string PlaceId { get; set; }
        public List<User>? Likes { get; set; } = new();
        public List<User>? DisLikes { get; set; } = new();



    }
}
