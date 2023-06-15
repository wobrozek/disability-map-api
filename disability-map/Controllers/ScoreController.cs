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


        [HttpGet]
        [Route("score/{idList}")]
        public async Task<List<Score>> Get([FromQuery] string[] idList)
        {
            List<Score> listScore = new List<Score>();

            foreach (string id in idList)
            {
                listScore.Add(await ScoreById(id));
            }

            return listScore;
        }

        public async Task<Score> ScoreById(string id)
        {
            //return likes and dislikes for id
            var element = await _context.Score.FindAsync(id);
            if (element is not null)
            {
                return element;
            }

            //if element does't contain score create score
            Score newScore = new Score(id);
            _context.Score.Add(newScore);
            _context.SaveChanges();

            return newScore;
        }
    }
}
