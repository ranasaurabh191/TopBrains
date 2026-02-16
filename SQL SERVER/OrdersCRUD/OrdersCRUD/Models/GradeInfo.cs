using System;
using System.Collections.Generic;

namespace OrdersCRUD.Models;

public partial class GradeInfo
{
    public decimal StudentId { get; set; }

    public decimal SectionId { get; set; }

    public string GradeTypeCode { get; set; } = null!;

    public decimal GradeCodeOccurance { get; set; }

    public decimal NumericGrade { get; set; }

    public virtual SectionInfo Section { get; set; } = null!;

    public virtual StudentInfo Student { get; set; } = null!;
}
