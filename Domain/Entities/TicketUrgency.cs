
using System;

namespace Domain.Entities
{
    public class TicketUrgency
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Urgency { get; set; } = string.Empty;
        public ICollection<Ticket> Tickets { get; set; } = [];
    }
}
