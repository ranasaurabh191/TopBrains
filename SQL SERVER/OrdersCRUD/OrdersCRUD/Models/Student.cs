using System;
using System.Collections.Generic;

namespace OrdersCRUD.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? StudentName { get; set; }

    public virtual ICollection<Mark> Marks { get; set; } = new List<Mark>();
}
