
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public abstract class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public Guid CategoryItemId { get; set; }
        public virtual CategoryItem? CategoryItem { get; set; }
        public Guid TicketUrgencyId { get; set; }
        public virtual TicketUrgency? TicketUrgency { get; set; }
        public ICollection<Image> Images { get; set; } = [];
    }
}
