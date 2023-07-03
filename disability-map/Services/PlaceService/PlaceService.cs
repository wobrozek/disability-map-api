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

                if (user.MyPlaces.Any(el => el.PlaceId == placeId))
                {
                    await _context.Place.Where(t => t.PlaceId == placeId).ExecuteDeleteAsync();
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

                var oldPlace = user.MyPlaces.FirstOrDefault(e => e.PlaceId == placeId);

                if (oldPlace is null)
                {
                    response.Success = false;
                    response.Message = "place with that id doesn't exist";
                    return response;
                }

                oldPlace = _mapper.Map<PostPlaceDto,Place>(place,oldPlace);

                await _context.SaveChangesAsync();

                response.Data = oldPlace.PlaceId;
                
            }
            catch (Exception er)
            {
                response.Success = false;
                response.Message = er.Message;
            }

            return response;
        }

        public Task<ServiceResponse<List<Place>>> GetPlacesByRadius(List<double> ll, Double radius, PlaceType? placeType)
        {
            throw new NotImplementedException();
        }
    }
}
