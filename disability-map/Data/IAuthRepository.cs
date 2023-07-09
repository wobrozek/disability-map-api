using disability_map.Dtos;
using disability_map.Models;

namespace disability_map.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<bool> FieldExists(string username, string field);
        Task<ServiceResponse<UserDataDto>> Login(string login, string password);
    }
}
