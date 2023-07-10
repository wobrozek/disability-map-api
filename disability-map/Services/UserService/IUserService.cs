using disability_map.Dtos;
using disability_map.Models;

namespace disability_map.Services.UserService
{
    public interface IUserService
    {
        int GetUserId();

        Task<ServiceResponse<List<GetPlaceDto>>> GetUserPlaces(int id);
        Task<ServiceResponse<List<GetReservationByUser>>> GetUserReservations(int id);
        Task<ServiceResponse<int>> PutUser(int id, string imagePath);
    }
}
