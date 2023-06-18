using disability_map.Data;
using disability_map.Models;
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
        private readonly DbMainContext _context;
        public ScoreController(DbMainContext context) => _context = context;


        private async Task<Score> AddToBase(string id)
        {
            var element = await _context.Score.FindAsync(id);
            if (element is not null)
            {
                return element;
            }

            //if element does't contain score create score
            //Score newScore = new Score(id);
            //_context.Score.Add(newScore);
            //_context.SaveChanges();

            return element;
        }


        [HttpGet]
        [Route("score/{id}")]
        public async Task<ActionResult<Score>> ScoreById(string id)
        {
            Score element = await AddToBase(id);

            return Ok(element);
        }
    }
}
