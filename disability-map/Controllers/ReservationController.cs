using disability_map.Dtos;
using disability_map.Models;
using disability_map.Services.SmsService;
using disability_map.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace disability_map.Controllers
{
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IUserService _userService;

        public ReservationController(IReservationService reservationService ,IUserService userService)
        {
            _reservationService = reservationService;
            _userService = userService;
        }


        [HttpPost, Authorize]
        public async Task<ActionResult<string>> CreateReservation(PostReservationDto reservation)
        {
            int userId = _userService.GetUserId();
            return Ok(await _reservationService.AddSchedule(reservation, userId));
        }

        [HttpDelete, Authorize]
        public async Task<ActionResult<string>> DeleteReservation(PostReservationDto reservation)
        {
            int userId = _userService.GetUserId();
            return Ok(await _reservationService.CancelSchedule(reservation, userId));
        }
    }
}
