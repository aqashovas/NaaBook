using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    public class Exam
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        [Range(1, 50)]
        public int Examresult { get; set; }

        public int TeacherId { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public Student Student { get; set; }

        public Teacher Teacher { get; set; }


    }
}