using Inmersys.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmersys.Core.Repositories
{
    public interface IEmployeesRepository : IRepository<Employees>
    {
        Task<List<Employees>> GetAllEmployeesAsync();
    }
}
