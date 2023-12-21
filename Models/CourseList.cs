using System;
using System.Collections.Generic;

namespace HighSchoolSystem.Models;

public partial class CourseList
{
    public int CourseListId { get; set; }

    public int? GradeInfo { get; set; }

    public DateTime? SetDate { get; set; }

    public int? FkstudentId { get; set; }

    public int? FkcourseId { get; set; }

    public virtual Course? Fkcourse { get; set; }

    public virtual Student? Fkstudent { get; set; }
}
