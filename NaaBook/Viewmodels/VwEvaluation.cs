using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NaaBook.Models;
namespace NaaBook.Viewmodels
{
    public class VwEvaluation
    {
        public List<Evaluationtable> Evaluationtables { get; set; }

        public List<Freework> Freeworks { get; set; }

        public List<Laboratory> Laboratories { get; set; }
    }
}