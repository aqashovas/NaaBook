using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    //müəllimlər
    public class Teacher
    {
        public int Id { get; set; }

        //adı
        public string Name { get; set; }

        //soyadı
        public string Surname { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public List<Timetable> Timetables { get; set; }
    }
}