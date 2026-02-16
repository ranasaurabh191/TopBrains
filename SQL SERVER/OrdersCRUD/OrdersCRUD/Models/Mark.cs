using System;
using System.Collections.Generic;

namespace OrdersCRUD.Models;

public partial class Mark
{
    public int MarkId { get; set; }

    public int? StudentId { get; set; }

    public int? Marks { get; set; }

    public virtual Student? Student { get; set; }
}
