
using DataAccess.EFCore.DBContext;
using Domain.Entities;
using Domain.Interfaces.EntitiesIRepo;

namespace DataAccess.EFCore.Repositories.EntitiesRepo
{
    public class TicketUrgencyRepository(ApplicationDbContext context) :
        GenericRepository<TicketUrgency>(context),
        ITicketUrgencyRepository
    {
    }
}
