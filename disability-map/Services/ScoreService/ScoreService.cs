using AutoMapper;
using disability_map.Data;
using disability_map.Dtos;
using disability_map.Models;
using Microsoft.EntityFrameworkCore;

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
                PlaceId = scoreElement.PlaceId,
                DisLikes = scoreElement.DisLikes.Count(),
                Likes = scoreElement.Likes.Count(),
            };

            response.Data = dto;

            return response;
        }
        // toggle number of likes
        public async Task<ServiceResponse<int>> upVote(string id, string userId)
        {
            var response = new ServiceResponse<int>();

            try
            {
                Score scoreElement = await _context.Score.FindAsync(id);
                User user= await _context.User.FindAsync(userId);

                deleteIfExist(user, scoreElement.DisLikes);
                bool toUpvote = deleteIfExist(user, scoreElement.Likes);

                if (!toUpvote)
                {
                    scoreElement.Likes.Add(user);
                }

                response.Data = scoreElement.Likes.Count();
            }
            catch (Exception error)
            {
                response.Success = false;
                response.Message = error.Message;
            }
            
            return response;
        }

        // toggle number of dislikes
        public Task<ServiceResponse<int>> downVote(string id,string userId)
        {
            throw new NotImplementedException();
        }


        //return true and delete user from score relations or return false if not exist
        public bool deleteIfExist(User user,List<User> list )
        {
            if(list.Any(listUser => listUser.Id == user.Id))
            {
                list.Remove(user);
                return true;
            }
            return false;
        }

    }
}
