using disability_map.Dtos;
using disability_map.Models;

namespace disability_map.Services.ScoreService
{
    public interface IScoreService
    {
        Task<Score> GetScoreById(string id);
        Task<Score> upVote(string id);
        Task<Score> downVote(string id);
    }
}
