using System;
using System.Collections.Generic;

namespace OrdersCRUD.Models;

public partial class InstructorInfo
{
    public decimal InstructorId { get; set; }

    public string InstructorFirstName { get; set; } = null!;

    public string InstructorLastName { get; set; } = null!;

    public string? StreetAddress { get; set; }

    public string? ZipCode { get; set; }

    public virtual ICollection<SectionInfo> SectionInfos { get; set; } = new List<SectionInfo>();

    public virtual ZipcodeInfo? ZipCodeNavigation { get; set; }
}
