using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces.EntitiesIRepo;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        ICategoryItemRepository CategoryItems { get; }
        IStudentRepository Students { get; }
        IEmployeeRepository Employees { get; }
        ITicketRepository Tickets { get; }
        ITicketUrgencyRepository TicketUrgencies { get; }
        IImageRepository Images { get; }
        Task<int> Complete();
    }
}
