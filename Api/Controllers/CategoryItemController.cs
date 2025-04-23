using DataAccess.EFCore.Mappers;
using DataAccess.EFCore.Repositories;
using Domain.DTOs.CategoryDtos;
using Domain.DTOs.CategoryItemDtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryItemController(IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpPost]
        public async Task<IActionResult> Create(CategoryItemCreateDto categoryItemCreateDto)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var categoryItem = categoryItemCreateDto.ToCategoryItemFromCreateDto();
                _unitOfWork.CategoryItems.Add(categoryItem);
                await _unitOfWork.Complete();
                return Ok(new CategoryItemDto { Name = categoryItem.Name });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll ()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var categoryItems = await _unitOfWork.CategoryItems.GetAll();
                return Ok(categoryItems.Select(c => c.ToCategoryItemDto()));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
