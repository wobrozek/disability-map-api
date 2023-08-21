using disability_map.DataAnnotations;
using disability_map.Dtos;
using disability_map.Models;
using disability_map.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace disability_map.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("Places"), Authorize]
        public async Task<ActionResult<Score>> upvote()
        {
            int userId = _userService.GetUserId();
            return Ok(await _userService.GetUserPlaces(userId));
        }

        [HttpPut,Authorize]
        [ValidationFilter]
        public async Task<ActionResult<ServiceResponse<int>>> PutUser(string imagePath)
        {
            int userId = _userService.GetUserId();
            return Ok(await _userService.PutUser(userId, imagePath));
        }

        [HttpGet("Reservations"), Authorize]
        public async Task<ActionResult<ServiceResponse<int>>> GetUserReservations()
        {
            int userId = _userService.GetUserId();
            return Ok(await _userService.GetUserReservations(userId));
        }
    }
}
