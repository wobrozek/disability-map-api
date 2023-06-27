using disability_map.Dtos;
using disability_map.Models;

namespace disability_map.Services.PlaceService
{
    public interface IPlaceService
    {
        Task<ServiceResponse<List<GetPlaceDto>>> GetUserPlaces(int id);

        Task<ServiceResponse<List<GetPlaceDto>>> GetPlacesByRadius(string placeId, Double radius);

        Task<ServiceResponse<int>> EditPlace(GetPlaceDto place);

        Task<ServiceResponse<string>> DeletePlace(string placeId);

        Task<ServiceResponse<int>> CreatePlace(PostPlaceDto place);

    }
}