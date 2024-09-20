using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmersys.Core.Dtos
{
    public class BaseErrorDto
    {
        public ErrorDto Error { get; set; } = new();
    }
}
