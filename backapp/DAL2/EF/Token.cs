using System;
using System.Collections.Generic;

namespace DAL.EF;

public partial class Token
{
    public int Id { get; set; }

    public string? Tkey { get; set; }

    public DateTime? CreationTime { get; set; }

    public DateTime? ExpirationTime { get; set; }

    public string? Username { get; set; }

    public string? Post { get; set; }
}
