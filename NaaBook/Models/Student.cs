using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NaaBook.Models
{
    //tələbələr
    public class Student
    {
        public int Id { get; set; }

        //ad
        public string Name { get; set; }

        //soyad
        public string Surname { get; set; }

        //ataadı
        public string Fathername { get; set; }

        //istifadəçi adı
        public string Username { get; set; }

        //parol
        public string Password { get; set; }

        public int GroupId { get; set; }

        public Group Group { get; set; }

        public List<Evaluationtable> Evaluationtables { get; set; }

        public List<Colloquium> Colloquims { get; set; }

        public List<Exam> Exams { get; set; }




    }
}