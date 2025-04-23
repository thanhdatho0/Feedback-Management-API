using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.ImageDtos;
using Microsoft.AspNetCore.Http;

namespace Domain.Interfaces.IServices
{
    public interface IImageUploadService
    {
        public Task CreateTicketImage(IFormFile file, ImageCreateDto imageCreateDto, string baseUrl);
        public Task<string> CreateUrl(IFormFile file, string baseUrl);
    }
}
