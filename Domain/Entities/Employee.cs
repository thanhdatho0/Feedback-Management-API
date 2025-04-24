
namespace Domain.Entities
{
    public class Employee : User
    {
        public virtual ICollection<Ticket> Tickets { get; set; } = [];
    }
}
