
using System.Reflection.Emit;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.EFCore.DBContext
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : IdentityDbContext<AppUser>(option)
    {

        #region DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryItem> CategoryItems { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketUrgency> TicketUrgencies { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Ticket>()
                .HasOne(t => t.Employee)
                .WithMany(e => e.Tickets) // hoặc .WithMany(e => e.Tickets) nếu Employee có List<Ticket>
                .HasForeignKey(t => t.EmployeeId)
                .IsRequired(false) // ✅ Cho phép null
                .OnDelete(DeleteBehavior.Cascade); // hoặc .Restrict nếu không muốn xóa cascade


            List<IdentityRole> roles =
            [
                new IdentityRole
                {
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "3",
                    Name = "Student",
                    NormalizedName = "STUDENT"
                },
            ];

            builder.Entity<IdentityRole>().HasData(roles);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
