using System;
using System.Collections.Generic;

namespace OrdersCRUD.Models;

public partial class EnrollmentInfo
{
    public decimal StudentId { get; set; }

    public decimal SectionId { get; set; }

    public DateOnly? EnrollmentDate { get; set; }

    public virtual SectionInfo Section { get; set; } = null!;

    public virtual StudentInfo Student { get; set; } = null!;
}
