using Inmersys.Api.Data.Context;
using Inmersys.Core.Repositories;
using Inmersys.Data.Repositories;

namespace Inmersys.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InmersysDbContext _context;
        private EmployeesRepository _employeesRepository;
        public UnitOfWork(InmersysDbContext context) { 
            this._context = context;
        }

        public IEmployeesRepository Employees => _employeesRepository = _employeesRepository ?? new EmployeesRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose() 
        {
            _context.Dispose();
        }
    }
}
