using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmersys.Core.Dtos
{
    public class EmployeeResponseDto : BaseErrorDto
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateOnly CreatedAt { get; set; }
    }
}
