using disability_map.Dtos;
using disability_map.Models;

namespace disability_map.Services.ScoreService
{
    public interface IScoreService
    {
        Task<ServiceResponse<GetScoreDto>> GetScoreById(string id, int? userId = 0);
        Task<ServiceResponse<int>> upVote(string id, int userId);
        Task<ServiceResponse<int>> downVote(string id, int userId);
        Task<ServiceResponse<List<GetScoreDto>>> GetListOfScoreById(List<string> id, int? userId = 0);
    }
}
