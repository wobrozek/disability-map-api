using disability_map.Data;
using disability_map.Dtos;
using disability_map.Models;
using disability_map.Services.ScoreService;
using disability_map.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;

namespace disability_map.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService _scoreService;
        private readonly IUserService _userService;

        public ScoreController(IScoreService scoreService, IUserService userService)
        {
            _scoreService = scoreService;
            _userService = userService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Score>> ScoreById(string id)
        {
           return Ok(await _scoreService.GetScoreById(id));
        }

        [HttpPut("upvote/{id}"), Authorize]
        public async Task<ActionResult<Score>> upvote(string id)
        {
            int userId =_userService.GetUserId();
            return Ok(await _scoreService.upVote(id,userId));
        }

        [HttpPut("downvote/{id}"), Authorize]
        public async Task<ActionResult<Score>> downvote(string id)
        {
            int userId = _userService.GetUserId();
            return Ok(await _scoreService.downVote(id, userId));
        }
    }
}
