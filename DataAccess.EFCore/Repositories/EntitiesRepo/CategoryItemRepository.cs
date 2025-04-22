
using DataAccess.EFCore.DBContext;
using Domain.Entities;
using Domain.Interfaces.EntitiesIRepo;

namespace DataAccess.EFCore.Repositories.EntitiesRepo
{
    public class CategoryItemRepository(ApplicationDbContext context) : 
        GenericRepository<CategoryItem>(context), 
        ICategoryItemRepository
    {
    }
}
