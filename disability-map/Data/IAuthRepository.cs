﻿using disability_map.Models;

namespace disability_map.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> FieldExists(string username, string field);
    }
}
