using Inmersys.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmersys.Core.Dtos
{
    public class GetListEmployeesDto: BaseErrorDto
    {
        public List<Employees> Employees { get; set; } = new();
    }
}
