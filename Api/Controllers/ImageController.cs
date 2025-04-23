using DataAccess.EFCore.Mappers;
using Domain.DTOs.ImageDtos;
using Domain.Interfaces;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController(IImageUploadService imageUploadService, IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IImageUploadService _imageUploadService = imageUploadService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ImageCreateDto imageCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var baseUrl = $"{Request.Scheme}://{Request.Host}";
                imageCreateDto.Url = await _imageUploadService.CreateUrl(imageCreateDto.File, baseUrl);
                
                var images = imageCreateDto.ToImageFromCreateDto();
                try
                {
                    _unitOfWork.Images.Add(images);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }

                await _unitOfWork.Complete();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
