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



    }
}