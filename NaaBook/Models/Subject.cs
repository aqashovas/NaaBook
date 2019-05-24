using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Timetable> Timetables { get; set; }

        public List<Lessonsection> Lessonsections { get; set; }

        public List<Laboratory> Laboratories { get; set; }

        public List<Freework> Freeworks { get; set; }




    }
}