using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    public class Evaluationtable
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public string MarkOrAttendanceFirst { get; set; }

        public string MarkOrAttendanceSecond { get; set; }

        public int TeacherId { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public Student Student { get; set; }

        public Teacher Teacher { get; set; }

    }
}