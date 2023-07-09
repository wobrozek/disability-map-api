using disability_map.Models;

namespace disability_map.Services.PhotoService
{
    public interface IPhotoService
    {
        Task<ServiceResponse<string>> UploadImage(IFormFile file);
    }
}
