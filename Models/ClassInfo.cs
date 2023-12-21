using System;
using System.Collections.Generic;

namespace HighSchoolSystem.Models;

public partial class ClassInfo
{
    public int ClassInfoId { get; set; }

    public string? ProgramName { get; set; }

    public string? Year { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
