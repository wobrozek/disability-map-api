using disability_map.Data;
using disability_map.Dtos;
using disability_map.Models;
using disability_map.Services.SmsService;

namespace disability_map.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly DbMainContext _context;

        public ReservationService(DbMainContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<int>> AddSchedule(PostReservationDto reservation, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<int>> CancelSchedule(PostReservationDto reservation, int userId)
        {
            throw new NotImplementedException();
        }

    }
}
