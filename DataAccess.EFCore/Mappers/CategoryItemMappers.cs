using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.CategoryItemDtos;
using Domain.Entities;

namespace DataAccess.EFCore.Mappers
{
    public static class CategoryItemMappers
    {
        public static CategoryItemDto ToCategoryItemDto(this CategoryItem categoryItem)
        {
            return new CategoryItemDto
            {
                Id = categoryItem.Id,
                Name = categoryItem.Name,
            };
        }

        public static CategoryItem ToCategoryItemFromCreateDto(this CategoryItemCreateDto categoryItemCreateDto)
        {
            return new CategoryItem
            {
                CategoryId = categoryItemCreateDto.CategoryId,
                Name = categoryItemCreateDto.Name,
            };
        }
    }
}
