
namespace Domain.Entities
{
    public class ResponseTicket : Ticket
    {
        public string EmployeeId { get; set; } = string.Empty;
        public virtual Employee? Employee { get; set; }
    }
}
