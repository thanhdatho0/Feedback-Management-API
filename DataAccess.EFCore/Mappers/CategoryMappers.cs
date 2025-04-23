using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.CategoryDtos;
using Domain.Entities;

namespace DataAccess.EFCore.Mappers
{
    public static class CategoryMappers
    {
        public static Category ToCategoryFromCreateDto(this CategoryCreateDto categoryCreateDto)
        {
            return new Category
            {
                Name = categoryCreateDto.Name,
            };
        }

        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                CategoryItems = category.CategoryItems.Select(c => c.ToCategoryItemDto())
            };
        }
    }
}
