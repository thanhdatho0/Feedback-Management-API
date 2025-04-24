
using DataAccess.EFCore.DBContext;
using Domain.Entities;
using Domain.Interfaces.EntitiesIRepo;

namespace DataAccess.EFCore.Repositories.EntitiesRepo
{
    public class TicketRepository(ApplicationDbContext context) : 
        GenericRepository<Ticket>(context), 
        ITicketRepository
    {
    }
}
