using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace NaaBook.Models
{
    public class AcademyContext:DbContext
    {
        public AcademyContext() : base("AcademyContext")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<Evaluationtable> Evaluationtables { get; set; }

        public DbSet<Colloquium> Colloquiums { get; set; }

        public DbSet<Lessonmaterial> Lessonmaterials { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Timetable> Timetables { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public DbSet<Laboratory> Laboratories { get; set; }

        public DbSet<Freework> Freeworks { get; set; }

        public DbSet<Lessonsection> Lessonsections { get; set; }

        public DbSet<Admin> Admins { get; set; }












    }
}