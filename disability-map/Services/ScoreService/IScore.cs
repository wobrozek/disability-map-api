using disability_map.Models;

namespace disability_map.Services.ScoreService
{
    public interface IScore
    {
        Task<Score> GetScoreById(string id);
        Task<Score> upVote(string id);

        Task<Score> downVote(string id);
    }
}
