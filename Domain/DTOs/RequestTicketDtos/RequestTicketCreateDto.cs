using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTOs.RequestTicketDtos
{
    public class RequestTicketCreateDto
    {
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string StudentId { get; set; } = string.Empty;
        public Guid CategoryItemId { get; set; }
        public Guid TicketUrgencyId { get; set; }
    }
}
