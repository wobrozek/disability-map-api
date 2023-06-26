using disability_map.Dtos;
using disability_map.Models;

namespace disability_map.Services.PlaceService
{
    public interface IPlaceService
    {
        Task<ServiceResponse<GetPlaceDto>> GetPlaceById(string id);

        Task<ServiceResponse<GetPlacesDto>> GetPlacesByRadius(string id, Double radius);

        Task<ServiceResponse<GetPlaceDto>> EditPlace(Place place);

        Task<ServiceResponse<GetPlaceDto>> DeletePlace(Place place);







    }
}