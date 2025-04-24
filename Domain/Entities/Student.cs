
namespace Domain.Entities
{
    public class Student : User
    {
        public virtual ICollection<Ticket> Tickets { get; set; } = [];
    }
}
