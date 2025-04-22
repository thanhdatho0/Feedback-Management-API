
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore.DBContext
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : IdentityDbContext(option)
    {

        #region DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryItem> CategoryItems { get; set; }
        public DbSet<RequestTicket> RequestTickets { get; set; }
        public DbSet<ResponseTicket> ResponseTickets { get; set; }
        public DbSet<TicketUrgency> TicketUrgencies { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        #endregion



    }
}
