using AutoMapper;
using disability_map.Models;

namespace disability_map.Services.ScoreService
{
    public class ScoreService : IScore {
        private readonly IMapper _mapper;

        public ScoreService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<Score> downVote(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Score> GetScoreById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Score> upVote(string id)
        {
            throw new NotImplementedException();
        }
    }
}
