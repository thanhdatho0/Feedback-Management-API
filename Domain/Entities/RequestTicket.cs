
namespace Domain.Entities
{
    public class RequestTicket : Ticket
    {
        public Guid StudentId { get; set; }
        public virtual Student? Student { get; set; }
    }
}
