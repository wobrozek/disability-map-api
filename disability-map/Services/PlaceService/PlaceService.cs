
using AutoMapper;
using disability_map.Data;
using disability_map.Dtos;
using disability_map.Models;
using disability_map.Services.UserService;
using Microsoft.EntityFrameworkCore;

namespace disability_map.Services.PlaceService
{
    public class PlaceService : IPlaceService
    {
        private readonly IMapper _mapper;
        private readonly DbMainContext _context;

        public PlaceService(IMapper mapper, DbMainContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<string>> CreatePlace(PostPlaceDto place,int userId)
        {
            var response = new ServiceResponse<string>();

            try
            {
                User user = await _context.User.FindAsync(userId);

      
                Place newPlace = _mapper.Map<Place>(place);

                newPlace.Owner = user;
                await _context.Place.AddAsync(newPlace);
                _context.SaveChanges();
                response.Data = newPlace.PlaceId;
            }
            catch(Exception er)
            {
                response.Success = false;
                response.Message = er.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<string>> DeletePlace(string placeId ,int userId )
        {
            var response = new ServiceResponse<string>();

            try
            {
                User user = await _context.User.FindAsync(userId);
                await _context.Entry(user).Collection(p => p.MyPlaces).Query().LoadAsync();

                if (user.MyPlaces.Any(el=> el.PlaceId == placeId))
                {
                    await _context.Place.Where(t => t.PlaceId == placeId).ExecuteDeleteAsync
                    //var placeToDelete =_context.Place.Attach(new Place { PlaceId = placeId });
                    //placeToDelete.State = EntityState.Deleted;
                    //await _context.SaveChangesAsync();
                }
                else
                {
                    response.Success = false;
                    response.Message = "user doesn't have place with that id";
                }
                
            }
            catch (Exception er)
            {
                response.Success = false;
                response.Message = er.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<string>> EditPlace(PostPlaceDto place, int userId, string placeId)
        {
            var response = new ServiceResponse<string>();

            try
            {
                User user = await _context.User.FindAsync(userId);
                await _context.Entry(user).Collection(p => p.MyPlaces).Query().LoadAsync();

                if (user.MyPlaces.Any(el => el.PlaceId == placeId))
                {
                    Place newPlace = _mapper.Map<Place>(place);
                    _context.Place.Attach(newPlace);

                    await _context.SaveChangesAsync();
                    response.Data = newPlace.PlaceId;
                }
                else
                {
                    response.Success = false;
                    response.Message = "user doesn't have place with that id";
                }
            }
            catch (Exception er)
            {
                response.Success = false;
                response.Message = er.Message;
            }

            return response;
        }

        public Task<ServiceResponse<List<GetPlaceDto>>> GetPlacesByRadius(string placeId, double radius)
        {
            throw new NotImplementedException();
        }
    }
}
