
using disability_map.Dtos;
using disability_map.Models;

namespace disability_map.Services.PlaceService
{
    public class PlaceService : IPlaceService
    {
        public Task<ServiceResponse<int>> CreatePlace(PostPlaceDto place)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<string>> DeletePlace(string placeId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> EditPlace(GetPlaceDto place)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetPlaceDto>>> GetPlacesByRadius(string placeId, double radius)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<List<GetPlaceDto>>> GetUserPlaces(int id)
        {
            throw new NotImplementedException();
        }
    }
}
