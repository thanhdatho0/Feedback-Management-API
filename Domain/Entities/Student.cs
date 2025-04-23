
namespace Domain.Entities
{
    public class Student : User
    {
        public virtual ICollection<RequestTicket> RequestTickets { get; set; } = [];
    }
}
