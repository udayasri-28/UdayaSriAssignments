using System;
using System.Collections.Generic;

namespace DBFirstEFinApp.Models;

public partial class VwCustOrderView1
{
    public string CustomerId { get; set; } = null!;

    public string? ContactName { get; set; }

    public int OrderId { get; set; }

    public string? Expr1 { get; set; }

    public decimal? Freight { get; set; }

    public string CompanyName { get; set; } = null!;

    public string? City { get; set; }
}
