﻿
using System;

namespace Domain.Entities
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();  
        public string Name { get; set; } = string.Empty;
        public ICollection<CategoryItem> CategoryItems { get; set; } = [];
    }
}
