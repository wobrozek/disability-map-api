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
        public async Task<ServiceResponse<List<GetScoreDto>>> GetListOfScoreById(List<string> idList, int? userId = 0)
        {
            var response = new ServiceResponse<List<GetScoreDto>>();
            response.Data = new List<GetScoreDto>();

            foreach(string id in idList)
            {
                var score = await GetScoreById(id,userId);
                response.Data.Add(score.Data);
            }

            return response;
        }
            public async Task<ServiceResponse<GetScoreDto>> GetScoreById(string id, int? userId = 0)
        {
            var response = new ServiceResponse<GetScoreDto>();

            var element = await _context.Score.FindAsync(id);
            if (element is not null)
            {
                await _context.Entry(element).Collection(p => p.Likes).Query().LoadAsync();
                await _context.Entry(element).Collection(p => p.DisLikes).Query().LoadAsync();

                var scoreDto = new GetScoreDto()
                {
                    PlaceId = element.PlaceId,
                    DisLikes = element.DisLikes.Count(),
                    Likes = element.Likes.Count(),
                    UserData = 0
                };

                //check that user have likes or dislikes
                if(userId != 0)
                {
                    if (element.Likes.Any(l => l.Id == userId))
                    {
                        scoreDto.UserData = 1;
                    }
                    else if (element.DisLikes.Any(l => l.Id == userId))
                    {
                        scoreDto.UserData = -1;
                    }
                }
                

                response.Data = scoreDto;
                return response;
            }

            //if element does't contain score create score
            Score scoreElement =new Score()
            {
                PlaceId=id,
            };

            _context.Score.Add(scoreElement);
            await _context.SaveChangesAsync();

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
        public async Task<ServiceResponse<int>> upVote(string id, int userId)
        {
            var response = new ServiceResponse<int>();

            try
            { 
                Score scoreElement = await _context.Score.FindAsync(id);
                User user= await _context.User.FindAsync(userId);
                
                // refresh context for entity in relation
                await _context.Entry(scoreElement).Collection(p => p.Likes).Query().LoadAsync();
                await _context.Entry(scoreElement).Collection(p => p.DisLikes).Query().LoadAsync();

                if (scoreElement == null)
                {
                    response.Message = "element with " + id + " doesn't exist";
                    response.Success = false;
                    return response;
                }

                await deleteIfExistAsync(user, scoreElement.DisLikes);
                bool toUpvote = await deleteIfExistAsync(user, scoreElement.Likes);

                if (!toUpvote)
                {
                    scoreElement.Likes.Add(user);
                }

                var attach = _context.Score.Attach(scoreElement);
                attach.State = EntityState.Modified;

                await _context.SaveChangesAsync();
                int likes = scoreElement.Likes.Count();

                response.Data = likes;
            }
            catch (Exception error)
            {
                response.Success = false;
                response.Message = error.Message;
            }
            
            return response;
        }

        // toggle number of dislikes
        public async Task<ServiceResponse<int>> downVote(string id,int userId)
        {
            var response = new ServiceResponse<int>();

            try
            {
                Score scoreElement = await _context.Score.FindAsync(id);
                User user = await _context.User.FindAsync(userId);


                if (scoreElement == null)
                {
                    response.Message = "element with " + id + " doesn't exist";
                    response.Success = false;
                    return response;
                }

                // refresh context for entity in relation
                await _context.Entry(scoreElement).Collection(p => p.Likes).Query().LoadAsync();
                await _context.Entry(scoreElement).Collection(p => p.DisLikes).Query().LoadAsync();

                await deleteIfExistAsync(user, scoreElement.Likes);
                bool toDisLike = await deleteIfExistAsync(user, scoreElement.DisLikes);

                if (!toDisLike)
                {
                    scoreElement.DisLikes.Add(user);
                }

                var attach = _context.Score.Attach(scoreElement);
                attach.State = EntityState.Modified;

                await _context.SaveChangesAsync();
                int likes = scoreElement.Likes.Count();

                response.Data = likes;
            }
            catch (Exception error)
            {
                response.Success = false;
                response.Message = error.Message;
            }

            return response;
        }


        //return true and delete user from score relations or return false if not exist
        public async Task<bool> deleteIfExistAsync(User user, ICollection<User> list )
        {
            if(list.Any(listUser => listUser.Id == user.Id))
            {
                list.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
