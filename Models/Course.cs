using System;
using System.Collections.Generic;

namespace HighSchoolSystem.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseInfo { get; set; }

    public int? FkemployeeId { get; set; }

    public virtual ICollection<CourseList> CourseLists { get; set; } = new List<CourseList>();

    public virtual Employee? Fkemployee { get; set; }
}
