using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.CategoryItemDtos;

namespace Domain.DTOs.CategoryDtos
{
    public class CategoryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<CategoryItemDto> CategoryItems { get; set; } = [];
    }
}
