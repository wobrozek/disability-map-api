using AutoMapper;
using disability_map.Data;
using disability_map.Dtos;
using disability_map.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace disability_map.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DbMainContext _context;
        private readonly IMapper _mapper;

        public UserService(IHttpContextAccessor httpContextAccessor, DbMainContext context, IMapper mapper)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _mapper = mapper;
        }

        public int GetUserId()
        {
            int result;
            if(_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated == false)return 0;

            result = int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            return result;
                
        }

 

        public async Task<ServiceResponse<int>> PutUser(int id,string imagePath)
        {
            ServiceResponse<int> response = new ServiceResponse<int>();
            try
            {
                var user = await _context.User.FindAsync(id);
                user.ImagePath = imagePath;

                await _context.SaveChangesAsync();

                response.Data = id;
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message; 
            }
            

            return response;
        }

        public async Task<ServiceResponse<List<GetPlaceDto>>> GetUserPlaces(int id)
        {
            var response = new ServiceResponse<List<GetPlaceDto>>();

            try
            {
                User user = await _context.User.FindAsync(id);
                await _context.Entry(user).Collection(p => p.MyPlaces).Query().Include(p => p.Cords).AsNoTracking().LoadAsync();

                List<GetPlaceDto> responseList =  _mapper.Map<List<Place>,List<GetPlaceDto>>(user.MyPlaces);
                response.Data = responseList;

                return response;
            }
            catch (Exception er)
            {
                response.Success = false;
                response.Message = er.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetReservationByUser>>> GetUserReservations(int id)
        {
            var response = new ServiceResponse<List<GetReservationByUser>>();

            return response;
        }

    }
}
