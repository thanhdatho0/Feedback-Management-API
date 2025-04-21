
namespace Domain.Entities
{
    public class Employee : User
    {
        public ICollection<ResponseTicket> ResponseTickets { get; set; } = [];
    }
}
