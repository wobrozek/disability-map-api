using disability_map.Dtos;
using disability_map.Models;

namespace disability_map.Services.SmsService
{
    public interface IReservationService
    {
        Task<ServiceResponse<int>> AddSchedule(PostReservationDto reservation, int userId);
        Task<ServiceResponse<int>> CancelSchedule(PostReservationDto reservation, int userId);
    }
}
