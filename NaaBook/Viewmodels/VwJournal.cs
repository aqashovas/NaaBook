using NaaBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Viewmodels
{
    public class VwJournal
    {

        public string Laboratory { get; set; }

        public List<Evaluationtable> Evaluationtables { get; set; }

        public List<Lessonmaterial> Lessonmaterials { get; set; }

        public int Lessonsection { get; set; }

        public string Freework { get; set; }

        public List<Teacher> Teachers { get; set; }

        public Exam Exam { get; set; }

        public Colloquium  Colloquium { get; set; }


    }
}