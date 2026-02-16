using System;
using System.Collections.Generic;

namespace OrdersCRUD.Models;

public partial class Orderitem
{
    public int OrderItemId { get; set; }

    public int? OrderId { get; set; }

    public string? ProductName { get; set; }

    public int? Quantity { get; set; }
}
