using System;
using System.Collections.Generic;

namespace OrdersCRUD.Models;

public partial class StudentInfo
{
    public decimal StudentId { get; set; }

    public string StudentFirstName { get; set; } = null!;

    public string StudentLastName { get; set; } = null!;

    public string? StreetAddress { get; set; }

    public string? ZipCode { get; set; }

    public virtual ICollection<EnrollmentInfo> EnrollmentInfos { get; set; } = new List<EnrollmentInfo>();

    public virtual ICollection<GradeInfo> GradeInfos { get; set; } = new List<GradeInfo>();

    public virtual ZipcodeInfo? ZipCodeNavigation { get; set; }
}
