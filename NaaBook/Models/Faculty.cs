using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    //fakültələr
    public class Faculty
    {
        public int Id { get; set; }

        //adı
        public string Name { get; set; }

        public List<Department> Departments { get; set; }
    }
}