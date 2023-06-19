using System.Text.Json.Serialization;

namespace disability_map.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PlaceType
    {
        BlindPlace = 1,
        Lift = 2,
        Toilet = 3
    }
}
