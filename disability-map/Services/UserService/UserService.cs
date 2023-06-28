using disability_map.Data;
using disability_map.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace disability_map.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DbMainContext _context;

        public UserService(IHttpContextAccessor httpContextAccessor, DbMainContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
        }

        public int GetUserId()
        {
            int result;

            return result = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                
        }

        public async Task<ServiceResponse<List<Place>>> GetUserPlaces(int id)
        {
            var response = new ServiceResponse<List<Place>>();

            try
            {
                User user = await _context.User.Include(s => s.MyPlaces).Where(s => s.Id == id).FirstOrDefaultAsync<User>();
                response.Data= user.MyPlaces.ToList();

                return response;
            }
            catch (Exception er)
            {
                response.Success = false;
                response.Message = er.Message;
            }

            return response;
        }
    }
}
