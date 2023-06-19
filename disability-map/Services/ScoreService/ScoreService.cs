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

        public Task<ServiceResponse<int>> downVote(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<GetScoreDto>> GetScoreById(string id)
        {
            var response = new ServiceResponse<GetScoreDto>();

            var element = await _context.Score.FindAsync(id);
            if (element is not null)
            {
                var scoreDto = new GetScoreDto()
                {
                    PlaceId = element.PlaceId,
                    DisLikes = element.DisLikes.Count(),
                    Likes = element.Likes.Count(),
                };
                response.Data = scoreDto;
                return response;
            }

            //if element does't contain score create score
            Score scoreElement =new Score()
            {
                PlaceId=id,
            };

            _context.Score.Add(scoreElement);
            _context.SaveChanges();

            var dto = new GetScoreDto()
            {
                PlaceId = element.PlaceId,
                DisLikes = element.DisLikes.Count(),
                Likes = element.Likes.Count(),
            };

            response.Data = dto;

            return response;
        }

        public Task<ServiceResponse<int>> upVote(string id)
        {
            throw new NotImplementedException();
        }
    }
}
