using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    //Dərs cədvəli
    public class Timetable
    {
        public int Id { get; set; }

        public string Day { get; set; }

        public string Time { get; set; }

        public string Classroom { get; set; }

        public bool Status { get; set; }

        public int SemesterNo { get; set; }

        public string Weeklysection { get; set; }

        public int TeacherId { get; set; }

        public int GroupId { get; set; }

        public int SubjectId { get; set; }

        public Group Group { get; set; }

        public Teacher Teacher { get; set; }

        public Subject Subject { get; set; }
    }
}