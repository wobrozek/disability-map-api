using disability_map.Data;
using disability_map.Models;
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

        public string GetUserId()
        {
            string result = string.Empty;

            return result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                
        }
    }
}
