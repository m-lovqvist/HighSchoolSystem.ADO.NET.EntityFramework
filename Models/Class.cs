using System;
using System.Collections.Generic;

namespace HighSchoolSystem.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public int? FkclassInfoId { get; set; }

    public virtual ClassInfo? FkclassInfo { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
