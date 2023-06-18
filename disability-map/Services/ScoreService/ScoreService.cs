using AutoMapper;
using disability_map.Data;
using disability_map.Dtos;
using disability_map.Models;

namespace disability_map.Services.ScoreService
{
    public class ScoreService : IScoreService {
        private readonly IMapper _mapper;
        private readonly DbMainContext _context;

        public ScoreService(IMapper mapper, DbMainContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<Score> downVote(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Score> GetScoreById(string id)
        {
            var element = await _context.Score.FindAsync(id);
            if (element is not null)
            {
                return element;
            }

            //if element does't contain score create score
            AddScoreDto dtoScore = new AddScoreDto() { PlaceId = id};
            Score newScore = _mapper.Map<Score>(dtoScore);
            _context.Score.Add(newScore);
            _context.SaveChanges();

            return newScore;
        }

        public Task<Score> upVote(string id)
        {
            throw new NotImplementedException();
        }
    }
}
