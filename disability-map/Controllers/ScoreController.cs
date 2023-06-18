using disability_map.Data;
using disability_map.Dtos;
using disability_map.Models;
using disability_map.Services.ScoreService;
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

        public ScoreController(IScoreService scoreService)
        {
            _scoreService = scoreService;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Score>> ScoreById(string id)
        {
           return Ok(await _scoreService.GetScoreById(id));
        }
    }
}
