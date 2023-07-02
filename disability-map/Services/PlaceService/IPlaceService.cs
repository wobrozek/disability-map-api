using disability_map.Dtos;
using disability_map.Models;

namespace disability_map.Services.PlaceService
{
    public interface IPlaceService
    {

        Task<ServiceResponse<List<GetPlaceDto>>> GetPlacesByRadius(string placeId, Double radius);

        Task<ServiceResponse<string>> EditPlace(PostPlaceDto place, int userId, string placeId);

        Task<ServiceResponse<string>> DeletePlace(string placeId, int userId);

        Task<ServiceResponse<string>> CreatePlace(PostPlaceDto place, int userId);

    }
}