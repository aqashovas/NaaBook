using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Viewmodels
{
    public class VwEvaluation
    {
        public List<int> StudentId { get; set; }

        public List<int> SubjectId { get; set; }

        public string Mark1 { get; set; }

        public string Mark2 { get; set; }

        public string TeacherId { get; set; }
    }
}