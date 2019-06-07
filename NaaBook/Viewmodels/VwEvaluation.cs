using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NaaBook.Models;
namespace NaaBook.Viewmodels
{
    public class VwEvaluation
    {
        public List< Evaluationtable >Evaluationtable { get; set; }

        public List< Freework> Freework { get; set; }

        public List< Laboratory> Laboratory { get; set; }
    }
}