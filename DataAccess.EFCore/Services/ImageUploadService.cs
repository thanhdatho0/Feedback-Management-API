
using Domain.DTOs.ImageDtos;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Http;

namespace DataAccess.EFCore.Services
{
    public class ImageUploadSerivce : IImageUploadService
    {
        public Task CreateTicketImage(IFormFile file, ImageCreateDto imageCreateDto, string baseUrl)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateUrl(IFormFile file, string baseUrl)
        {
            var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return $"{baseUrl}/images/{fileName}";
        }
    }
}
