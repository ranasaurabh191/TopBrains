using System;
using System.Collections.Generic;

namespace OrdersCRUD.Models;

public partial class Sale
{
    public int SaleId { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public DateOnly? SaleDate { get; set; }

    public virtual Product? Product { get; set; }
}
