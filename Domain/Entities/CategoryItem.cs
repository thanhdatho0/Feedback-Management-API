
using System;

namespace Domain.Entities
{
    public class CategoryItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; } = [];
    }
}
