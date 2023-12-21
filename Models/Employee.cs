using System;
using System.Collections.Generic;

namespace HighSchoolSystem.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Title { get; set; }

    public DateTime? HireDate { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? Address { get; set; }

    public string? Zip { get; set; }

    public int? FkprofessionId { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Profession? Fkprofession { get; set; }
}
