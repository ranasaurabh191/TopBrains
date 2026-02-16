using System;
using System.Collections.Generic;

namespace OrdersCRUD.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateOnly OrderDate { get; set; }

    public int CustomerId { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? Status { get; set; }
}
