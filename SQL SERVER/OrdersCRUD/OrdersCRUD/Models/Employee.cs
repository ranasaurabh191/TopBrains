using System;
using System.Collections.Generic;

namespace OrdersCRUD.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Dept { get; set; }

    public int? Salary { get; set; }
}
