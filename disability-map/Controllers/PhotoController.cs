using disability_map.Dtos;
using disability_map.Services.PhotoService;
using disability_map.Services.PlaceService;
using Microsoft.AspNetCore.Mvc;

namespace disability_map.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        [HttpPost]
        public async Task<ActionResult<string>> GetPhototo([FromForm] ImageDto file)
        {
            return Ok(await _photoService.UploadImage(file.Image));
        }
    }
}
