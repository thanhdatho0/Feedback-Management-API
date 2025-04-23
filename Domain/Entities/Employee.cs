
namespace Domain.Entities
{
    public class Employee : User
    {
        public virtual ICollection<ResponseTicket> ResponseTickets { get; set; } = [];
    }
}
