using System;
using System.Collections.Generic;

namespace DAL.EF;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Pincode { get; set; }

    public string? Degree { get; set; }

    public string? Designation { get; set; }

    public string? Branch { get; set; }

    public int? DeptId { get; set; }

    public string? Status { get; set; }

    public int? Salary { get; set; }

    public string? BankAccount { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public int? RemLeave { get; set; }

    public virtual Department? Dept { get; set; }

    public virtual ICollection<Transaction> Transactions { get; } = new List<Transaction>();

    public virtual ICollection<Vacation> Vacations { get; } = new List<Vacation>();
}
