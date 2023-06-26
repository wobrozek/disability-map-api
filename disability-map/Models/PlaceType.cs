using System.Text.Json.Serialization;

namespace disability_map.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PlaceType
    {
        blindPlace = 1,
        elevators = 2,
        restrooms = 3
    }
}
