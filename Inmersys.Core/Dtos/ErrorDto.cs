using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inmersys.Core.Dtos
{
    public class ErrorDto
    {
        public bool IsError {  get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
