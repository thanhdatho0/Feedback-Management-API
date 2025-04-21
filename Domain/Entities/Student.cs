
namespace Domain.Entities
{
    public class Student : User
    {
        public ICollection<RequestTicket> RequestTickets { get; set; } = [];
    }
}
