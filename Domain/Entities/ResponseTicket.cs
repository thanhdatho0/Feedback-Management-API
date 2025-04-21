
namespace Domain.Entities
{
    public class ResponseTicket : Ticket
    {
        public Guid EmployeeId { get; set; }
        public virtual Employee? Employee { get; set; }
    }
}
