
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? Response { get; set; } 
        public Guid CategoryItemId { get; set; }
        public virtual CategoryItem? CategoryItem { get; set; }
        public Guid TicketUrgencyId { get; set; }
        public virtual TicketUrgency? TicketUrgency { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public virtual Student? Student { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
        public virtual Employee? Employee { get; set; }
        public virtual ICollection<Image> Images { get; set; } = [];
    }
}
