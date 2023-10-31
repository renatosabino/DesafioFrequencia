using DesafioFrequencia.Infra.Utils.Interfaces;
using Microsoft.AspNetCore.Http;

namespace DesafioFrequencia.Infra.Utils
{
    public class ImageUploadService : IImageUploadService
    {
        public async Task<string> UploadImageAsync(IFormFile formFile, string imageDirectory)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
            var filePath = Path.Combine(imageDirectory, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}
