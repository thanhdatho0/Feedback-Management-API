
using DataAccess.EFCore.DBContext;
using Domain.Entities;
using Domain.Interfaces.EntitiesIRepo;

namespace DataAccess.EFCore.Repositories.EntitiesRepo
{
    public class StudentRepository(ApplicationDbContext context) : 
        GenericRepository<Student> (context), 
        IStudentRepository
    {
    }
}
