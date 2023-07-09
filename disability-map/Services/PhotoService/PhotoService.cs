using Azure.Storage.Blobs;
using disability_map.Models;

namespace disability_map.Services.PhotoService
{
    public class PhotoService : IPhotoService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public PhotoService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }
        public async Task<ServiceResponse<string>> UploadImage(IFormFile file)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();

            try
            {
                string blobName = Nanoid.Nanoid.Generate() + ".jpg";

                //upload to azure
                var containerInstance = _blobServiceClient.GetBlobContainerClient("images");
                var blobInstance = containerInstance.GetBlobClient(blobName);
                await blobInstance.UploadAsync(file.OpenReadStream());

                response.Data = "https://disabilityblob.blob.core.windows.net/images/" + blobName;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }

        public async Task<ServiceResponse<string>> DeleteImage(string id)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();

            try
            {
                //upload to azure
                var containerInstance = _blobServiceClient.GetBlobContainerClient("images");
                var blobInstance = containerInstance.GetBlobClient(id+".jpg");
                await blobInstance.DeleteAsync();

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;

        }
    }
}
