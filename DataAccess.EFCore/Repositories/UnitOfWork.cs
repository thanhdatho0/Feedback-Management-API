using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EFCore.DBContext;
using DataAccess.EFCore.Repositories.EntitiesRepo;
using Domain.Interfaces;
using Domain.Interfaces.EntitiesIRepo;

namespace DataAccess.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposedValue;
        private readonly ApplicationDbContext _context;
        public ICategoryRepository Categories { get; private set; }
        public ICategoryItemRepository CategoryItems { get; private set; }
        public IEmployeeRepository Employees {  get; private set; }
        public IStudentRepository Students { get; private set; }
        public ITicketRepository Tickets { get; private set; }
        public ITicketUrgencyRepository TicketUrgencies { get; private set; }
        public IImageRepository Images { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categories = new CategoryRepository(_context);
            CategoryItems = new CategoryItemRepository(_context);
            Employees = new EmployeeRepository(_context);
            Students = new StudentRepository(_context);
            Tickets = new TicketRepository(_context);
            TicketUrgencies = new TicketUrgencyRepository(_context);
            Images = new ImageRepository(_context);
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UnitOfWork()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
