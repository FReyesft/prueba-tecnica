using Inmersys.Api.Data.Context;
using Inmersys.Core.Models;
using Inmersys.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmersys.Data.Repositories
{
    public class EmployeesRepository : Repository<Employees>, IEmployeesRepository
    {
        private readonly InmersysDbContext _context;

        public EmployeesRepository(InmersysDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Employees>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }
    }

}
