using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    //Qruplar
    public class Group
    {
        public int Id { get; set; }

        //adı
        public string Name { get; set; }

        public int DepartmenId { get; set; }

        public List<Student> Students { get; set; }

        public Department Department { get; set; }

        public List<Timetable> Timetables { get; set; }

        public List<Lessonmaterial> Lessonmaterials { get; set; }

        public List<Lessonsection> Lessonsections { get; set; }




    }
}