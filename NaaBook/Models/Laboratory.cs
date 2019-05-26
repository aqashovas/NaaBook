using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    public class Laboratory
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public int Count { get; set; }

        public Student Student { get; set; }

        public Subject Subject { get; set; }
    }
}