using System;
using System.Collections.Generic;

namespace DAL.EF;

public partial class Transaction
{
    public int Id { get; set; }

    public int? EmpId { get; set; }

    public int? Amount { get; set; }

    public DateTime? Date { get; set; }

    public string? Month { get; set; }

    public int AdminId { get; set; }

    public virtual Admin Admin { get; set; } = null!;

    public virtual Employee? Emp { get; set; }
}
