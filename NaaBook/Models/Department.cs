using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    //kafedralar
    public class Department
    {
        public int Id { get; set; }

        //adı
        public string Name { get; set; }

        public List<Group> Groups { get; set; }

        public Faculty Faculty { get; set; }

        public List<Teacher> Teachers { get; set; }
    }
}