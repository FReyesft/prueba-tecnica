using System;
using System.Collections.Generic;

namespace Inmersys.Core.Models;

public partial class Employees
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly CreatedAt { get; set; }
}
