using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    public class Lessonmaterial
    {
        public int Id { get; set; }

        public string Day { get; set; }

        public string Theme { get; set; }

        public int GroupId { get; set; }

        public int SubjectId { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public Subject Subject { get; set; }

        public Group Group { get; set; }

    }
}