using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    public class Colloquium
    {
        public int Id { get; set; }

        [Range(1, 10)]
        public int Colloquium1 { get; set; }

        [Range(1, 10)]
        public int Colloquium2 { get; set; }

        [Range(1, 10)]
        public int Colloquium3 { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public Subject Subject { get; set; }


    }
}