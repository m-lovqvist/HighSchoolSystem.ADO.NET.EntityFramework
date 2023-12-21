using System;
using System.Collections.Generic;

namespace HighSchoolSystem.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PersonalNumber { get; set; }

    public string? Address { get; set; }

    public string? Zip { get; set; }

    public int? FkclassId { get; set; }

    public virtual ICollection<CourseList> CourseLists { get; set; } = new List<CourseList>();

    public virtual Class? Fkclass { get; set; }
}
