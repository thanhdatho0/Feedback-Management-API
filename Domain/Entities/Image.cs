using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Image
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Ult { get; set; } = string.Empty;
        public string Alt { get; set; } = string.Empty;
        public Guid TicketId { get; set; }
        public virtual RequestTicket? Ticket { get; set; }
    }
}
