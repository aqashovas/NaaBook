using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NaaBook.Models;
namespace NaaBook.Viewmodels
{
    public class VwEvaluation
    {
        public Evaluationtable Evaluationtable { get; set; }

        public Freework Freework { get; set; }

        public Laboratory Laboratory { get; set; }
    }
}