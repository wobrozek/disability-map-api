using Azure.Messaging.ServiceBus;
using disability_map.Data;
using disability_map.Dtos;
using disability_map.Models;
using disability_map.Services.SmsService;

namespace disability_map.Services.ReservationService
{
    public class ReservationService : IReservationService
    {
        private readonly DbMainContext _context;
        private readonly ServiceBusClient _serviceBusClient;

        public ReservationService(DbMainContext context, ServiceBusClient serviceBusClient)
        {
            _context = context;
            _serviceBusClient = serviceBusClient;
        }

        public async Task<ServiceResponse<long>> AddSchedule(PostReservationDto reservation, int userId)
        {
            var response = new ServiceResponse<long>();

            try
            {

                //add to database
                Reservation newMapperReservation = new Reservation()
                {
                    PlaceId = reservation.PlaceId,
                    UserId = userId
                };
                var newReservation = await _context.Reservations.AddAsync(newMapperReservation);

                //send message
                var serviceSender = _serviceBusClient.CreateSender("sms-queqe");
                ServiceBusMessage message = new ServiceBusMessage("sms");

                long seq = await serviceSender.ScheduleMessageAsync(message, DateTimeOffset.FromUnixTimeSeconds(reservation.UnixTimestamp));


                //save seq
                newReservation.Seq = seq;

                _context.SaveChanges();

                response.Data = seq;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public Task<ServiceResponse<int>> CancelSchedule(long seq)
        {
            var serviceSender = _serviceBusClient.CreateSender("sms-queqe");
            serviceSender.CancelScheduledMessageAsync(seq);
        }

    }
}
