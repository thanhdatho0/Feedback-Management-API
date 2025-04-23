using DataAccess.EFCore.Mappers;
using Domain.DTOs.CategoryDtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateDto categoryCreateDto)
        {
            try
            {
                if(!ModelState.IsValid) return BadRequest(ModelState);
                var category = categoryCreateDto.ToCategoryFromCreateDto();
                _unitOfWork.Categories.Add(category);
                await _unitOfWork.Complete();
                return Ok(new CategoryDto {Name = category.Name });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var categories = await _unitOfWork.Categories.GetAll();
                if (categories == null) return StatusCode(400, "Danh sách trống");
                return Ok(categories.Select(c => c.ToCategoryDto()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
