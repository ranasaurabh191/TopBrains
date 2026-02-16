using System;
using System.Collections.Generic;

namespace OrdersCRUD.Models;

public partial class SectionInfo
{
    public decimal SectionId { get; set; }

    public decimal? CourseNo { get; set; }

    public decimal SectionNo { get; set; }

    public decimal? InstructorId { get; set; }

    public string? Location { get; set; }

    public decimal? Capacity { get; set; }

    public virtual CourseInfo? CourseNoNavigation { get; set; }

    public virtual ICollection<EnrollmentInfo> EnrollmentInfos { get; set; } = new List<EnrollmentInfo>();

    public virtual ICollection<GradeInfo> GradeInfos { get; set; } = new List<GradeInfo>();

    public virtual InstructorInfo? Instructor { get; set; }
}
