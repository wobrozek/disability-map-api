
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
                response.Data = newPlace.PlaceId;
            }
            catch(Exception er)
            {
                response.Success = false;
                response.Message = er.Message;
            }

            return response;
        }

        public ServiceResponse<string> DeletePlace(string placeId ,int userId)
        {
            var response = new ServiceResponse<string>();

            try
            {
                Place place = new Place { PlaceId = placeId };
                _context.Place.Attach(place);
                _context.Place.Remove(place);
            }
            catch (Exception er)
            {
                response.Success = false;
                response.Message = er.Message;
            }

            return response;
        }

        public ServiceResponse<string> EditPlace(PostPlaceDto place, int userId)
        {
            var response = new ServiceResponse<string>();

            try
            {
                Place newPlace = _mapper.Map<Place>(place);
                _context.Place.Attach(newPlace);
                response.Data = newPlace.PlaceId;
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
