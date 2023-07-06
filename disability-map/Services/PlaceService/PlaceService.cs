using AutoMapper;
using disability_map.Data;
using disability_map.Dtos;
using disability_map.Models;
using disability_map.Services.UserService;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using Azure.Storage.Blobs;

namespace disability_map.Services.PlaceService
{
    public class PlaceService : IPlaceService
    {
        private readonly IMapper _mapper;
        private readonly DbMainContext _context;
        private readonly BlobServiceClient _blobServiceClient;

        public PlaceService(IMapper mapper, DbMainContext context, BlobServiceClient blobServiceClient)
        {
            _mapper = mapper;
            _context = context;
            _blobServiceClient = blobServiceClient;
        }

        public async Task<ServiceResponse<string>> CreatePlace(PostPlaceDto place,int userId)
        {
            var response = new ServiceResponse<string>();

            try
            {
                if (place.LL.Length < 2)
                {
                    response.Success = false;
                    response.Message = "parametr ll is not a list";
                }

                User user = await _context.User.FindAsync(userId);

                Cords placeCords = new Cords()
                {
                    Longitude = place.LL[0],
                    Latitude = place.LL[1]
                };

                Place newPlace = _mapper.Map<Place>(place);

                //insert relacions
                newPlace.Cords= placeCords;
                newPlace.Owner = user;
                newPlace.ImagePath = await UploadToAzureIfPhotoExists(place, _blobServiceClient);

                await _context.Place.AddAsync(newPlace);
                await _context.SaveChangesAsync();

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
                oldPlace.ImagePath = await UploadToAzureIfPhotoExists(place, _blobServiceClient);

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

        public async Task<ServiceResponse<List<Place>>> GetPlacesByRadius(List<double> ll, Double radius, PlaceType? placeType)
        {
            var response = new ServiceResponse<List<Place>>();


            var result = await (from place in _context.Place
                         where (Math.Abs(place.Cords.Latitude - ll[0]) <= radius) &&
                         (Math.Abs(place.Cords.Longitude - ll[1]) <= radius) &&
                         (placeType == null ? true : place.Type==placeType)
                         select place).ToListAsync();

            response.Data = result;

            return response;
        }

        public static async Task<string> UploadToAzureIfPhotoExists(IImageDto dto, BlobServiceClient blobServiceClient)
        {
            if (dto.Image is not null)
            {
                string blobName = Nanoid.Nanoid.Generate();

                //upload to azure
                var containerInstance = blobServiceClient.GetBlobContainerClient("images");
                var blobInstance = containerInstance.GetBlobClient(blobName);
                await blobInstance.UploadAsync(dto.Image.OpenReadStream());

                return "https://<storage_account_name>.blob.core.windows.net/images/" + blobName;
            }

            return "";
        }
    }
}
