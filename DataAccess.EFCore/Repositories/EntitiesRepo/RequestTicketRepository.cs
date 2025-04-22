
using DataAccess.EFCore.DBContext;
using Domain.Entities;
using Domain.Interfaces.EntitiesIRepo;

namespace DataAccess.EFCore.Repositories.EntitiesRepo
{
    public class RequestTicketRepository(ApplicationDbContext context) : 
        GenericRepository<RequestTicket>(context), 
        IRequestTicketRepository
    {
    }
}
