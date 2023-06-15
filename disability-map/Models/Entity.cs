using System.ComponentModel.DataAnnotations;

namespace disability_map.Models
{
    public abstract class Entity
    {
        [Required]
        protected string Id { get; set; }
    }
}
