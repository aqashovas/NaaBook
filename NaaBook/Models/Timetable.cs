using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    //Dərs cədvəli
    public class Timetable
    {
        public int Id { get; set; }

        public DateTime Day { get; set; }

        public DateTime Time { get; set; }

        public int TeacherId { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public Teacher Teacher { get; set; }
    }
}