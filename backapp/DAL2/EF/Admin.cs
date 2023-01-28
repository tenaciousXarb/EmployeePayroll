using System;
using System.Collections.Generic;

namespace DAL.EF;

public partial class Admin
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Transaction> Transactions { get; } = new List<Transaction>();

    public virtual ICollection<Vacation> Vacations { get; } = new List<Vacation>();
}
