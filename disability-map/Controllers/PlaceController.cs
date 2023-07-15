using disability_map.Dtos;
using disability_map.Models;
using disability_map.Services.PlaceService;
using disability_map.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace disability_map.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;
        private readonly IUserService _userService;

        public PlaceController(IPlaceService placeService, IUserService userService)
        {
            _placeService = placeService;
            _userService = userService;
        }
 

        [HttpPost,Authorize]
        public async Task<ActionResult<Score>> CreatePlace(PostPlaceDto place)
        {
            int userId = _userService.GetUserId();
            return Ok(await _placeService.CreatePlace(place,userId));
        }

        [HttpDelete("{id}"), Authorize]
        public async Task<ActionResult<Score>> DeletePlace(string id)
        {
            int userId = _userService.GetUserId();
            return Ok(await _placeService.DeletePlace(id, userId));
        }

        [HttpPut("{id}"), Authorize]
        public async Task<ActionResult<Score>> EditPlace(PostPlaceDto place,string id)
        {
            int userId = _userService.GetUserId();
            return Ok(await _placeService.EditPlace(place, userId ,id));
        }

        [HttpGet("GetByRadius")]
        public async Task<ActionResult<List<Place>>> GetPlaceByRadius([FromQuery] GetByRadiusDto radiusDto)
        {
            return Ok(await _placeService.GetPlacesByRadius(radiusDto.LL, radiusDto.Radius,radiusDto.PlaceType));
        }

        [HttpGet("{id}/Reservations")]
        public async Task<ActionResult<List<Place>>> GetPlaceReservations(string id)
        {
            return Ok(await _placeService.GetPlaceReservations(id));
        }


    }
}
