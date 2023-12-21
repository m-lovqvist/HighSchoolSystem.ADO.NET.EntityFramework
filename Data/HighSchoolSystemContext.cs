using System;
using System.Collections.Generic;
using HighSchoolSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HighSchoolSystem.Data;

public partial class HighSchoolSystemContext : DbContext
{
    public HighSchoolSystemContext()
    {
    }

    public HighSchoolSystemContext(DbContextOptions<HighSchoolSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassInfo> ClassInfos { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseList> CourseLists { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Profession> Professions { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-64QT8T3;Initial Catalog=HighSchoolSystem;Integrated Security=True;Trusted_Connection=True;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.Property(e => e.ClassId)
                .ValueGeneratedNever()
                .HasColumnName("ClassID");
            entity.Property(e => e.ClassName).HasMaxLength(20);
            entity.Property(e => e.FkclassInfoId).HasColumnName("FKClassInfoID");

            entity.HasOne(d => d.FkclassInfo).WithMany(p => p.Classes)
                .HasForeignKey(d => d.FkclassInfoId)
                .HasConstraintName("FK_Classes_ClassInfo");
        });

        modelBuilder.Entity<ClassInfo>(entity =>
        {
            entity.ToTable("ClassInfo");

            entity.Property(e => e.ClassInfoId)
                .ValueGeneratedNever()
                .HasColumnName("ClassInfoID");
            entity.Property(e => e.ProgramName).HasMaxLength(50);
            entity.Property(e => e.Year)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("CourseID");
            entity.Property(e => e.CourseInfo).HasMaxLength(50);
            entity.Property(e => e.FkemployeeId).HasColumnName("FKEmployeeID");

            entity.HasOne(d => d.Fkemployee).WithMany(p => p.Courses)
                .HasForeignKey(d => d.FkemployeeId)
                .HasConstraintName("FK_Courses_Employees");
        });

        modelBuilder.Entity<CourseList>(entity =>
        {
            entity.Property(e => e.CourseListId)
                .ValueGeneratedNever()
                .HasColumnName("CourseListID");
            entity.Property(e => e.FkcourseId).HasColumnName("FKCourseID");
            entity.Property(e => e.FkstudentId).HasColumnName("FKStudentID");
            entity.Property(e => e.SetDate).HasColumnType("datetime");

            entity.HasOne(d => d.Fkcourse).WithMany(p => p.CourseLists)
                .HasForeignKey(d => d.FkcourseId)
                .HasConstraintName("FK_CourseLists_Courses");

            entity.HasOne(d => d.Fkstudent).WithMany(p => p.CourseLists)
                .HasForeignKey(d => d.FkstudentId)
                .HasConstraintName("FK_CourseLists_Students");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.Property(e => e.EmployeeId)
                .ValueGeneratedNever()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.BirthDate).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.FkprofessionId).HasColumnName("FKProfessionID");
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Title).HasMaxLength(10);
            entity.Property(e => e.Zip).HasMaxLength(10);

            entity.HasOne(d => d.Fkprofession).WithMany(p => p.Employees)
                .HasForeignKey(d => d.FkprofessionId)
                .HasConstraintName("FK_Employees_Professions");
        });

        modelBuilder.Entity<Profession>(entity =>
        {
            entity.Property(e => e.ProfessionId)
                .ValueGeneratedNever()
                .HasColumnName("ProfessionID");
            entity.Property(e => e.ProfessionName).HasMaxLength(20);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("StudentID");
            entity.Property(e => e.Address).HasMaxLength(30);
            entity.Property(e => e.FirstName).HasMaxLength(15);
            entity.Property(e => e.FkclassId).HasColumnName("FKClassID");
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.PersonalNumber).HasMaxLength(30);
            entity.Property(e => e.Zip).HasMaxLength(10);

            entity.HasOne(d => d.Fkclass).WithMany(p => p.Students)
                .HasForeignKey(d => d.FkclassId)
                .HasConstraintName("FK_Students_Classes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
