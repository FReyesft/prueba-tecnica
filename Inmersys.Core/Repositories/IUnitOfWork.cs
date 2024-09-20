using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmersys.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeesRepository Employees { get; }
        Task<int> CommitAsync();
    }
}
