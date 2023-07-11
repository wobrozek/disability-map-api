using disability_map.Models;

namespace disability_map.Services.SmsService
{
    public interface IReservationService
    {
        Task<ServiceResponse<int>> AddSchedule(int unixTimeStamp);

        Task<ServiceResponse<int>> CancelSchedule(int unixTimeStamp);
    }
}
