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

        [HttpGet("{id}/Places"), Authorize]
        public async Task<ActionResult<Score>> upvote(string id)
        {
            int userId = _userService.GetUserId();
            return Ok(await _userService.GetUserPlaces(userId));
        }
    }
}
