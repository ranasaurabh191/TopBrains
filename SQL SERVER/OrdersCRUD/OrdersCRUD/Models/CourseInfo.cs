using System;
using System.Collections.Generic;

namespace OrdersCRUD.Models;

public partial class CourseInfo
{
    public decimal CourseNo { get; set; }

    public decimal Cost { get; set; }

    public string CourseName { get; set; } = null!;

    public decimal? CoursePrerequisite { get; set; }

    public virtual ICollection<SectionInfo> SectionInfos { get; set; } = new List<SectionInfo>();
}
