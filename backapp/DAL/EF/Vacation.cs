using System;
using System.Collections.Generic;

namespace DAL.EF;

public partial class Vacation
{
    public int Id { get; set; }

    public int? EmpId { get; set; }

    public DateTime? Date { get; set; }

    public int? Nod { get; set; }

    public string? Status { get; set; }

    public int? AdminId { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual Employee? Emp { get; set; }
}
