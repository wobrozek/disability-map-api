using Azure;
using Azure.Messaging.ServiceBus;
using disability_map.Data;
using disability_map.Dtos;
using disability_map.Migrations;
using disability_map.Models;
using disability_map.Services.SmsService;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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
                    UserId = userId,
                    UnixTimestamp = reservation.UnixTimestamp
                    
                };
                var newReservation = await _context.Reservations.AddAsync(newMapperReservation);

                _context.SaveChanges();

                //send message

                var place = await _context.Place.FindAsync(reservation.PlaceId);

                DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                dateTime = dateTime.AddSeconds(newMapperReservation.Id).ToLocalTime();

                var sms = new Sms()
                { 
                    Message = string.Concat(place.Name," zostało zarezerwowane na godzinę ", dateTime.ToString()),
                    Phone = place.Phone
                };

                var serviceSender = _serviceBusClient.CreateSender("sms-queqe");
                ServiceBusMessage message = new ServiceBusMessage(JsonSerializer.Serialize(sms));

                long seq = await serviceSender.ScheduleMessageAsync(message, DateTimeOffset.FromUnixTimeSeconds(reservation.UnixTimestamp - 300));


                //save seq
                newReservation.Entity.Seq = seq;

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

        public async Task<ServiceResponse<int>> CancelSchedule(long seq, bool deleteFromQueue = true)
        {
            var response = new ServiceResponse<int>();
            try
            {
                await _context.Reservations.Where(s => s.Seq == seq).ExecuteDeleteAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            if (!deleteFromQueue) return response;

            var serviceSender = _serviceBusClient.CreateSender("sms-queqe");
            await serviceSender.CancelScheduledMessageAsync(seq);

            return response;
        }

    }
}
