
using disability_map.Dtos;
using disability_map.Models;

namespace disability_map.Services.PlaceService
{
    public class PlaceService : IPlaceService
    {
        public Task<ServiceResponse<GetPlaceDto>> DeletePlace(Place place)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetPlaceDto>> EditPlace(Place place)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetPlaceDto>> GetPlaceById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetPlacesDto>> GetPlacesByRadius(string id, double radius)
        {
            throw new NotImplementedException();
        }
    }
}
