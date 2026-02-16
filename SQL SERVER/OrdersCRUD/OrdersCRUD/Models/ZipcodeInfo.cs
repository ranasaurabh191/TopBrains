using System;
using System.Collections.Generic;

namespace OrdersCRUD.Models;

public partial class ZipcodeInfo
{
    public string ZipCode { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public virtual ICollection<InstructorInfo> InstructorInfos { get; set; } = new List<InstructorInfo>();

    public virtual ICollection<StudentInfo> StudentInfos { get; set; } = new List<StudentInfo>();
}
