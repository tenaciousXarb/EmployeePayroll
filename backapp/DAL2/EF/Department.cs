using System;
using System.Collections.Generic;

namespace DAL.EF;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Tallowance { get; set; }

    public int? Mallowance { get; set; }

    public int? Leave { get; set; }

    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
