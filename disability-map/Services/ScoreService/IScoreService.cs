﻿using disability_map.Dtos;
using disability_map.Models;

namespace disability_map.Services.ScoreService
{
    public interface IScoreService
    {
        Task<ServiceResponse<GetScoreDto>> GetScoreById(string id);
        Task<ServiceResponse<int>> upVote(string id);
        Task<ServiceResponse<int>> downVote(string id);
    }
}
