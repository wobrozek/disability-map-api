using disability_map.Dtos;
using disability_map.Models;

namespace disability_map.Services.SmsService
{
    public interface IReservationService
    {
        Task<ServiceResponse<long>> AddSchedule(PostReservationDto reservation, int userId);
        Task<ServiceResponse<int>> CancelSchedule(long seq);
    }
}
