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

        public DbSet<Department> Departments { get; set; }

        public DbSet<Faculty> Faculties { get; set; }
    }
}