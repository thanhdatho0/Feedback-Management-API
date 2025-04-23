
namespace Domain.Entities
{
    public class RequestTicket : Ticket
    {
        public string StudentId { get; set; } = string.Empty;
        public virtual Student? Student { get; set; }
    }
}
